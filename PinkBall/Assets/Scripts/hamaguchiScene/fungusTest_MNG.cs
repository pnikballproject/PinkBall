using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class fungusTest_MNG : MonoBehaviour {

    //呼び出すフローチャートオブジェクトの名前
    //※デバッグ　テスト用
    public Flowchart flowchart;

    //デバッグ　玉ポーズ用
    public GameObject tama;

    //デバッグテスト用 (再生するブロック名)
    public string blockName;

    //
    //Fungus_BlockTrigger blockTrigger;

    //ファンガス呼び出し用テストクラス
    public void callFungus()
    {
        //玉を一時的に停止させる
        tama.GetComponent<Rigidbody>().isKinematic = true;

        //再生するブロックネームに名前を入れる
        checkBlockName();

        Debug.Log("MNG　fungus呼び出しメソッド呼び出され");

        flowchart.ExecuteBlock(blockName);
    }

    //デバッグ用
    //再生するメッセージの識別に使うブロックネームを取得する
    public void checkBlockName()
    {
        int rand = Random.Range(1, 4);

        switch (rand)
        {
            case 1:
                blockName = "Test1_Block";
                break;
            case 2:
                blockName = "Test2_Block";
                break;
            case 3:
                blockName = "Test3_Block";
                break;
        }
    }

    //デバッグ用　
    //会話終了検知メソッド
    public void endTalk()
    {
        Debug.Log("endTalk呼び出され　ボールの動きを再開します");

        //玉の動きを再開させる

        tama.GetComponent<Rigidbody>().isKinematic = false;
        //tama.GetComponent<Rigidbody>().AddForce(Vector3.back);

        //Vector3 pos = new Vector3(-4.25f, -4.63f, -6.92f);
        tama.transform.position = new Vector3(-4.25f, -4.63f, -6.92f);

    }

}
