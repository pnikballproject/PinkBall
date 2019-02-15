using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class ResultSceneController : MonoBehaviour
{

    public Flowchart flowchart;

    public string Charaend;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flowchart.ExecuteBlock(Charaend);

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
