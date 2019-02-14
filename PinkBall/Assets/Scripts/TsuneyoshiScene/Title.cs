using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class Title : MonoBehaviour {

    //確認パネル
    public GameObject fixPanel;

    //キャラ1の選択アイコン
    public Image choiceChara1;

    //キャラ2の選択アイコン
    public Image choiceChara2;

    //ダイアログ表示中に他のアイコンをクリックさせないパネル
    public GameObject dontTochPanel;

    //ファンガスのフローチャート
    public Flowchart flowchart;

    //呼び出すブロックネーム
    string blockName;

    //キャラ毎の呼び出すブロックネーム
    public string chara01_start_BlockName;
    public string chara02_start_BlockName;

    //呼び出すイベントのBox Name
    //CHARA_01_01
    //CHARA_02_01

    //1のキャラが選択された際に呼び出される処理
    public void OnClickCharacter1()
    {
        Debug.Log("1のキャラが選択されました。");

        //呼び出す会話イベントの名前を代入
        blockName = chara01_start_BlockName;

        //選択アイコンを表示させる
        choiceChara1.gameObject.SetActive(true);

        //確認パネルアクティブメソッド
        fixPanelSetActive();

    }

    //2のキャラが選択された際に呼び出される処理
    public void OnClickCharacter2()
    {
        Debug.Log("2のキャラが選択されました。");

        //呼び出す会話イベントの名前を代入
        blockName = chara02_start_BlockName;

        //選択アイコンを表示させる
        choiceChara2.gameObject.SetActive(true);

        //確認パネルアクティブメソッド
        fixPanelSetActive();
    }

    //確認パネルをアクティブにする処理
    public void fixPanelSetActive()
    {
        //パネルを表示する
        fixPanel.SetActive(true);

        //ドンとタッチパネルをアクティブに
        dontTochPanel.SetActive(true);
    }

    //確認パネルをフォルスにする処理
    public void fixPanelSetFalse()
    {
        //パネルを消す
        fixPanel.SetActive(false);

        //ドンとタッチパネルを非アクティブに
        dontTochPanel.SetActive(false);

    }

    //確認パネルの　はい　が押された時の処理
    public void OnClickYesButton()
    {
        //キャラが喋る処理（ファンガスを呼び出す）
        flowchart.ExecuteBlock(blockName);

    }

    //確認パネルの　いいえ　が押された時の処理
    public void OnClickNoButton()
    {
        //選択アイコンを消す
        choiceChara1.gameObject.SetActive(false);
        choiceChara2.gameObject.SetActive(false);

        //確認パネルを消す
        fixPanelSetFalse();

    }

    //会話終了時
    public void endTitleTalk()
    {
        //シーン遷移演出入れるとしたらここ

        //Mainシーンに遷移
        SceneManager.LoadScene("Main");
    }

}