using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField] private float firstPosY;
    [SerializeField] private float secondPosY;
    [SerializeField] private float lastPosY;

    [SerializeField] int posNum;

    [SerializeField] GameObject explosionObject;

    [SerializeField] private UIController ui;

    public bool isDelete = false;

    bool isChange = false;
    bool isDeath = false;
    Vector3 tmp_pos;

    SpriteRenderer playerRenderer;
    
    void Start()
    {
        
        playerRenderer = GetComponent<SpriteRenderer>();

        posNum = 0;
        isChange = true;
        isDeath = false;

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
            playerRenderer.sprite = null;
            Instantiate(explosionObject, this.transform.position,  Quaternion.identity);
            isDelete = false;
            isDeath = true;
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
            int num = collision.gameObject.GetComponent<enemyController>().posNum;
            if(posNum == num && !isDeath  && !ui.isGameFinished){
                isDelete = true;
                ui.GameOver();
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
