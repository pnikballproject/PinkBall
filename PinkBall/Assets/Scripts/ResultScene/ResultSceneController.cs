using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class ResultSceneController : MonoBehaviour
{
    public Flowchart flowchart;

    public Text score;

    public void Start()
    {
        flowchart = GameObject.Find("SampleData/SampleFlowchart").GetComponent<Flowchart>();

        if (flowchart == false)
        {
            Debug.LogError("flowchartが格納されていません　このままだと正常に進行しません");
        }

        score.text = "score:" + GlobalData.GlobalScore;

    }

    void Update()
    {
        int charanumber = GlobalData.selectCharacterId;

        if (Input.GetMouseButtonDown(0))
        {
            switch (charanumber)
            {
                case 1:
                    flowchart.ExecuteBlock("Chara01-05");
                    break;
                case 2:
                    flowchart.ExecuteBlock("Chara02-05");
                    break;
            }

        }
    }
    
    public void endTitleTalk()
    {
        Debug.Log("会話終了メソッド呼び出され");

        //シーン遷移演出入れるとしたらここ

        //Mainシーンに遷移
        SceneManager.LoadScene("Title");
    }
}
