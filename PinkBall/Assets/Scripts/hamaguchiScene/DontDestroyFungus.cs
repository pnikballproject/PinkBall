using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyFungus : MonoBehaviour {

    //Mainシーンで使用する
    TalkEventController tec;

    //リザルトシーンで使用するマネージャ
    ResultSceneController rsc;

    void Start () {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Fungus_FlowChartのDontDestroy設定完了");
    }

    //メインシーン遷移後に初期化処理としてTalkEventControllerから呼び出される
    public void startUpMainScene(TalkEventController tec)
    {
        Debug.Log("FungusのMainシーン遷移初期化処理呼び出され");
        this.tec = tec;
        if (! this.tec == false)
        {
            Debug.Log("FungusのMainシーン遷移初期化処理完了");
        }
        else
        {
            Debug.LogError("FungusのMainシーン遷移初期化処理が完了していません。このままでは正常にゲームが進行しません");
        }
    }

    //Mainシーンでの会話終了時に呼ばれる終了処理
    public void endFungusEvent()
    {
        tec.endFungusEvent();
    }

    //リザルトシーンの会話終了時に呼ばれる終了処理
    public void endFungusEventResult()
    {
        rsc.endResultTalk();
    }

    //ResultSceneControllerを探す
    public void findResultSceneController(GameObject r)
    {
        Debug.Log("findResultSceneController呼び出され");
       rsc = r.GetComponent<ResultSceneController>();
    }

}
