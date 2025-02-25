using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class EndingCountDownPlayer : MonoBehaviour
{
     [SerializeField] private TextMeshProUGUI uiText;
    
    [SerializeField] private EndingUIController ui;
    [SerializeField] private GameObject seObject;

    [SerializeField] GameObject beamChargeSE;
    //[SerializeField]private playerController playerController;

    [SerializeField] private GameObject explainText;
    
    private void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<EndingUIController>();
        uiText = this.GetComponent<TextMeshProUGUI>();

        //playerController = GameObject.Find("Canvas").GetComponent<playerController>();
        
        /*if(GameObject.Find("NCMBSettings") != null){
            para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
        }*/

        PlayCountDown();
    }

    private void PlayCountDown()
    {
        var sequence = DOTween.Sequence();

        sequence
            .OnStart(() => UpdateText("3"))
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("2"))
            .AppendCallback(() => FadeOutText())
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("1"))
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("チャージ!"))
            .AppendCallback(() => FlagChangeStart())
            .Append(FadeOutText())
            .OnComplete(() => ResetStartText());
    }

    //テキストの更新
    private void UpdateText(string text)
    {
        InitializeAlpha();

        uiText.text = text;
    }

    //フェードアウトさせる
    private Tween FadeOutText()
    {
        return uiText.DOFade(0, 0.7f).SetEase(Ease.InExpo);
    }

    //アルファ値の初期化
    private void InitializeAlpha()
    {
        uiText.color  = new Color(uiText.color.r, uiText.color.g, uiText.color.b, 1.0f);
    }

    //ゲームスタート
    private void FlagChangeStart()
    {
        //uiコントローラあたりのisGameStartをTrueにする
        ui.isGameStart = true;
                
        //ゴングを鳴らす
        CallSE();
        Instantiate(beamChargeSE, Vector3.zero, Quaternion.identity);
        explainText.SetActive(false);
    }
    
    //ゲーム開始時のSEを鳴らす
    private void CallSE()
    {
        Instantiate(seObject, Vector3.zero, Quaternion.identity);
    }

    //中身を空文字にしてfinish時の演出に備える
    private Tween ResetStartText()
    {
        uiText.text = "";
        return uiText.DOFade(1, 0.1f).SetEase(Ease.InExpo);
    }
}
