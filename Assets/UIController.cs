using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using unityroom.Api;

public class UIController : MonoBehaviour
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

    [field: SerializeField] public bool isGameStart;
    [field: SerializeField] public bool isGameFinished;
    [field: SerializeField] public float time; 

    [SerializeField] public int score;

    [SerializeField] ParameterController para;

    
    
    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        isGameFinished = false;

        gameoverButtons.SetActive(false);
        
        score = 0;

        para = GameObject.Find("UnityroomApiClient").GetComponent<ParameterController>();  
        para.Hi_score = 0;
    }

    void Update()
    {
        if (isGameStart)
        {
            if(!isGameFinished)time -= Time.deltaTime;
            if (time < 0.0f)
            {
                time = 0;
                isGameStart = false;
                if(!isGameFinished) GameFinish();
                //GameFinish();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "討伐: "+ score +"点";
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
        gameOverText.text = "FINISH!";
        gameOverText.color = Color.red;
        //para.TotalScore = player.AnimalTotalHight;
        //para.TotalAnimalNum = player.AnimalNum;
        isGameFinished = true;
        
        UnityroomApiClient.Instance.SendScore(1, (float)score, ScoreboardWriteMode.Always);
        para.Hi_score = score;

        //gameoverButtons.SetActive(true);
        Instantiate(endSE, Vector3.zero, Quaternion.identity);
        DOVirtual.DelayedCall (3.0f, ()=> DoChangeScene());  
        
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
        FadeManager.Instance.LoadScene ("EndingScene", 1.5f);
    }

    public void AddScore(){
        if(isGameStart && !isGameFinished ) score+=10;
    }
}
