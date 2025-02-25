using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    
    [SerializeField] private float firstPosY;
    [SerializeField] private float secondPosY;
    [SerializeField] private float lastPosY;

    [SerializeField] GameObject explosionObject;

    [SerializeField] int posNum;

    public bool isDelete = false;
    bool isChange = false;
    Vector3 tmp_pos;

    
    void Start()
    {
        
        posNum = 0;
        isChange = true;

        tmp_pos = this.transform.position;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)){
            if(posNum > 0){
                posNum--;
                isChange = true;
            }
        }else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)){
            if(posNum < 2){
                posNum++;
                isChange = true;
            }
        }

        //爆殺
        if(isDelete){
            Instantiate(explosionObject, this.transform.position,  Quaternion.identity);
            isDelete = false;
        }

         if(isChange){
            if(posNum == 0){
                tmp_pos = this.transform.position;
                tmp_pos.y = firstPosY;
                this.transform.position = tmp_pos;
            }else if(posNum == 1){
                tmp_pos = this.transform.position;
                tmp_pos.y = secondPosY;
                this.transform.position = tmp_pos;
            }else{
                tmp_pos = this.transform.position;
                tmp_pos.y = lastPosY;
                this.transform.position = tmp_pos;
            }

            isChange = false;
        }
    }

    void FixedUpdate()
    {

    

    }

        void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("YES");
        if (collision.gameObject.tag == "Enemy")
        {
            int num = collision.gameObject.GetComponent<tutorialEnemyController>().posNum;
            if(posNum == num ){
                isDelete = true;
            }
        }
    }

    public void Up(){
            if(posNum > 0){
                posNum--;
                isChange = true;
            }
    }

    public void Down(){
        if(posNum < 2){
                posNum++;
                isChange = true;
            }
    }


}