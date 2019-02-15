using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class TalkEventController : MonoBehaviour {

    //マネージャークラス
    public Manager mng;

    //会話イベントが入ったイベントチャート
    Flowchart flowchart;

    //各キャラクター毎の会話イベントのブロック名
    public string[] chara01_blockNames;
    public string[] chara02_blockNames;

    private void Start()
    {
        //このシーン開始時にsampleDataとflowchartをFindする
        GameObject sampleData = GameObject.Find("SampleData");
        flowchart = sampleData.transform.Find("SampleFlowchart").GetComponent<Flowchart>();

        //チェック
        if (! flowchart == false)
        {
            Debug.Log("flowchartは正常にFindし格納できました");

            //ファンガス側のシーン移動時の初期化処理
            sampleData.GetComponent<DontDestroyFungus>().startUpMainScene(this);
        }
        else
        {
            Debug.LogError("flowchartが格納出来ていません。このままでは正常にゲームが進行しません");
        }
    }

    //マネージャークラスから呼ばれて任意のファンガスイベントを呼び出す処理　引数にはプレイヤーステータスの現在のヒット回数を渡してください
    public void toStartFungusTalkEvent(int hitNum)        
    {
        if (GlobalData.selectCharacterId == 1) //キャラ1を選択している場合
        {
            Debug.Log("今回再生される会話イベントはキャラID1の" + (hitNum + 1) + "回目のイベントです");
            flowchart.ExecuteBlock(chara01_blockNames[hitNum]);
        }else if (GlobalData.selectCharacterId == 2) //キャラ2を選択している場合
        {
            Debug.Log("今回再生される会話イベントはキャラID2の" + (hitNum + 1) + "回目のイベントです");
            flowchart.ExecuteBlock(chara02_blockNames[hitNum]);
        }
    }

    //会話終了時にファンガス側から呼ばれる処理
    public void endFungusEvent()
    {
        //マネージャ側にそれを通知
        mng.endFungusEvent();
    }





    //デバッグ用
    public void OnDebugButton()
    {
        toStartFungusTalkEvent(Random.Range(0, 3));
    }

}
