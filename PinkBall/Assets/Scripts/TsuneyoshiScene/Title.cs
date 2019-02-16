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

    //そのイメージ
    public Image Character1_Image;
    public Image Character2_Image;

    //選択中のキャラID
    public int charaId;

    //キャラボタン
    public Button chara1_Button;
    public Button chara2_Button;

    //pushstartText
    public Text startText;

    //InfoPanel
    public GameObject infoPanel;

    //スタート処理だけの
    bool isTouch;

    //スタート時効果音
    public AudioSource SE;

    public AudioClip startSE;

    private void Start()
    {
        //グローバル変数を初期化
        GlobalData.selectCharacterId = 0;
        GlobalData.GlobalScore = 0;
    }

    private void Update()
    {
        if (isTouch == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isTouch = true;

                //スタートテキストを非アクティブに
                startText.gameObject.SetActive(false);

                //効果音を鳴らす
                SE.PlayOneShot(startSE);

                //キャラ選択ボタンをアクティブに
                chara1_Button.gameObject.SetActive(true);
                chara2_Button.gameObject.SetActive(true);

                //InfoPanelをアクティブに
                infoPanel.SetActive(true);
            }
        }
    }

    //1のキャラが選択された際に呼び出される処理
    public void OnClickCharacter1()
    {
        Debug.Log("1のキャラが選択されました。");

        //呼び出す会話イベントの名前を代入
        blockName = chara01_start_BlockName;

        //選択キャラIDを一時的に保管
        charaId = 1;

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

        //選択キャラIDを一時的に保管
        charaId = 2;

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
        //効果音を鳴らす
        SE.PlayOneShot(startSE);

        //グローバル変数に選択キャラIDを代入
        GlobalData.selectCharacterId = charaId;

        //確認パネルを消す
        fixPanelSetFalse();

        //選択中ではないキャラのイメージを非表示にする
        if (charaId == 1) //選択中のキャラが1の場合
        {
            Character2_Image.GetComponent<Image>().color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 0 / 255.0f); 
        }else if (charaId == 2) //選択中のキャラが2の場合
        {
            Character1_Image.GetComponent<Image>().color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 0 / 255.0f); 
        }

        //キャラ選択してねパネルを消す
        infoPanel.SetActive(false);

        //キャラが喋る処理（ファンガスを呼び出す）
        Debug.Log("現在のblockNameは" + blockName);
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
        Debug.Log("会話終了メソッド呼び出され");

        //シーン遷移演出入れるとしたらここ

        //濱口テスト（他の人触らないでください）
        if (GameObject.Find("test_hama_obj")) //もし見つけられれば
        {
            GameObject.Find("test_hama_obj").GetComponent<hamaTestDont>().thisDestroy();
        }

        //Mainシーンに遷移
        SceneManager.LoadScene("Main");
    }

}