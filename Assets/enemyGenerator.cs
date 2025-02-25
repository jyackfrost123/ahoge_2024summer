using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class enemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private float enemyX;
    [SerializeField] private float firstPosY;
    [SerializeField] private float secondPosY;
    [SerializeField] private float lastPosY;
    [SerializeField] private float enemyZ;

    [SerializeField] private float generateTime;

    [SerializeField] private UIController ui;

    float time;

    bool isGenerate = false;

    void Start()
    {
        time = -1.5f;//カウント2秒+2秒

        isGenerate = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= generateTime){
            isGenerate = true;
            time = 0;
        }
    }

    void FixedUpdate()
    {
        if(isGenerate && !ui.isGameFinished){
            GenerateEnemy();
            isGenerate = false;
        }
    }

    public void GenerateEnemy(){

        Vector3 tmp_pos = new Vector3(enemyX, 0.0f, enemyX);

        int posNum = Random.Range(0,3);
        
        if(posNum == 0){
            tmp_pos = this.transform.position;
            tmp_pos.y = firstPosY;
        }else if(posNum == 1){
            tmp_pos = this.transform.position;
            tmp_pos.y = secondPosY;
        }else{
            tmp_pos = this.transform.position;
            tmp_pos.y = lastPosY;
        }

        GameObject obj = Instantiate(enemy, tmp_pos, Quaternion.identity);
        enemyController e = obj.GetComponent<enemyController>();
        e.posNum = posNum;
        e.moveXDif = e.moveXDif - (0.02f * (ui.score / 10));
        
    }



}
