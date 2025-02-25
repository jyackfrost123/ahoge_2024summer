using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using unityroom.Api;

public class ButtonController : MonoBehaviour
{

   //parametorController para;
   //public GameObject[] Omakes;
   [SerializeField] private UIController ui;
    
    
    void Start()
    {
     /*
     if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
     }
     */

     ui = GameObject.Find("Canvas").GetComponent<UIController>();
      
    }

    public void goTweet(){
       naichilab.UnityRoomTweet.Tweet ("bombshark_vs_spaceship", "あなたはボンバーシャークを、"+ui.score+"点"+"で討伐しましたが、人類は敗北…", "ahoge", "SpaceShipVSBombShark");
       //StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("ツイート本文をここに書く"));//画像あり
    }

    public void goRanking(){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
        UnityroomApiClient.Instance.SendScore(1, 1, ScoreboardWriteMode.Always);
    }

    public void goResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 0);
        UnityroomApiClient.Instance.SendScore(1, 1, ScoreboardWriteMode.Always);
    }
    
    
    /*
    public void go2ndRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 1);
    }

    public void go2ndResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 1);
    }
    */
    

    public void ReStart(){
        FadeManager.Instance.LoadScene ("GameScene", 0.5f);

        /*
        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameScene", 1.0f);
        }
        */
        
        
    }

    public void FastReStart(){
         SceneManager.LoadScene("GameScene");
    }

    public void Re2ndStart(){

        //FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);

        /*
        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);
        }
        */
        
        
    }

     public void Fast2ndReStart(){
         SceneManager.LoadScene("EndressGameScene");
    }

    public void goTutorial(){
        FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene ("Title", 0.5f);
    }

 
}
