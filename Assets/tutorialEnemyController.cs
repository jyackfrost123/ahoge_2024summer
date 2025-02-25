using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialEnemyController : MonoBehaviour
{
    [SerializeField] public float moveXDif;
    [SerializeField] private float finalbackX;

    [SerializeField] public int posNum = 0;

    [SerializeField] private GameObject explosionSE;


    void Start()
    {

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate (moveXDif, 0, 0);
		if (transform.position.x <= finalbackX) {
            Instantiate(explosionSE, this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
    }

}
