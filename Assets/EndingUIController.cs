using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using unityroom.Api;


public class EndingUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
        
    [SerializeField]
    private TextMeshProUGUI timerText;
    
    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private GameObject endSE;

    [SerializeField]
    private GameObject gameoverButtons;

    [field: SerializeField] public float time; 
    [field: SerializeField] public bool isGameFinished;

    [field: SerializeField] public bool isGameStart;


    [SerializeField] public int score;

    [SerializeField] ParameterController para;

    [SerializeField] GameObject beamSE;
    [SerializeField] GameObject explainTExt;

    
    
    // Start is called before the first frame update
    void Start()
    {
        gameoverButtons.SetActive(false);
        isGameFinished = false;
        isGameStart = false;

        para = GameObject.Find("UnityroomApiClient").GetComponent<ParameterController>();
        score = para.Hi_score; 
    }

    void Update()
    {
        if (isGameStart)
        {
            time -= Time.deltaTime;
            if (time < 0.0f)
            {
                time = 0;
                if(!isGameFinished) GameFinish();
                DOVirtual.DelayedCall (3.0f, ()=> DoChangeScene()); 
                //GameFinish();
            }

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)){
                AddScore();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "スペースパワー: "+ score +"点";
        //timerText.text = "残り: " + time.ToString("f2") + "秒";
        timerText.text = time.ToString("f2");
        
        //残り3秒以内
        if (time < 3.9f)
        {
            timerText.color = Color.red;
        }

    }
    
    //ゲーム終了時の処理
    void GameFinish()
    {
        gameOverText.text = "";
        gameOverText.color = Color.red;
        //para.TotalScore = player.AnimalTotalHight;
        //para.TotalAnimalNum = player.AnimalNum;
        isGameFinished = true;
        
        UnityroomApiClient.Instance.SendScore(1, (float)(score), ScoreboardWriteMode.Always);

        //gameoverButtons.SetActive(true);
        Instantiate(endSE, Vector3.zero, Quaternion.identity);
        Instantiate(beamSE, Vector3.zero, Quaternion.identity);

        explainTExt.SetActive(false);
        
    }

    public void GameOver(){
        gameOverText.text = "~敗北~";
        gameOverText.color = Color.red;

        isGameFinished = true;

        UnityroomApiClient.Instance.SendScore(1, (float)score, ScoreboardWriteMode.Always);

        gameoverButtons.SetActive(true);
        Instantiate(endSE, Vector3.zero, Quaternion.identity);

    }

    void DoChangeScene()
    {
        //フェード遷移とか入れる
        //FadeManager.Instance.LoadScene ("Ending", 1.5f);
    }

    public void AddScore(){
        if(isGameStart && !isGameFinished ) score++;
    }

    public void goTweet(){
       naichilab.UnityRoomTweet.Tweet ("bombshark_vs_spaceship", "あなたはボンバーシャークを、"+score+"点"+"で討伐！人類の勝利！", "ahoge", "SpaceShipVSBombShark");
       //StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("ツイート本文をここに書く"));//画像あり
    }

    public void buttonShipCharge(){
        if(!isGameFinished){
            AddScore();
        }
    }
}
