using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndingEnemyMover : MonoBehaviour
{
    Vector3 pos;

    [SerializeField] private GameObject beam;
    [SerializeField] private GameObject breakSE;

    [SerializeField] private GameObject buttons;

    [SerializeField] private GameObject endingSE;


    void Start()
    {
        pos = this.transform.position;

        beam.SetActive(false);

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(new Vector3(pos.x, -1.5f, pos.z), 1f).SetLoops(12, LoopType.Yoyo))
                .AppendCallback(() =>{
                    beam.SetActive(true);
                })
                .AppendInterval(1.5f)
                .AppendCallback(() =>{
                    beam.SetActive(false);
                    Instantiate(breakSE, Vector3.zero, Quaternion.identity);
                })
                .Append(transform.DOMove(new Vector3(pos.x, -10.8f, pos.z), 4f))
                .AppendCallback(() =>{
                    buttons.SetActive(true);
                    Instantiate(endingSE, Vector3.zero, Quaternion.identity);    
                }
                );

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
