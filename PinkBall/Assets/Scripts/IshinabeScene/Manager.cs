using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject[] gimmiks;
    public GameObject ballObj;
    public int eventID = -1;
    public PlayerStatus playerStatus;
    public ScorePanel scorePanel;
    public LifePanel lifePanel;

    Collision eventCol;
    GameObject eventObj;

    void Awake()
    {
        playerStatus.DefaultBallPoint = 3;
    }

    // Use this for initialization
    void Start () {
        
        Debug.Log("スタート残機数 " + playerStatus.Ball);
        Debug.Log("デフォルト残機数 " + playerStatus.DefaultBallPoint);
    }
	
	// Update is called once per frame
	void Update () {
        switch (eventID)
        {
            case 0:
                Gimic_Emission emission = eventObj.GetComponent<Gimic_Emission>();
                emission.Emission();
                emission.hitBasicProcessing(eventCol);
                playerStatus.Score = emission.GainScore;
                int point = playerStatus.Score;
                scorePanel.ShowScore(point);
                eventID = -1;
                break;

            case 1:
                Gimmik_GapObject gap = gimmiks[1].GetComponent<Gimmik_GapObject>();
                playerStatus.Score = gap.GainScore;
                point = playerStatus.Score;
                scorePanel.ShowScore(point);
                eventID = -1;
                break;

            case 2:
                Death death = gimmiks[2].GetComponent<Death>();
                ballObj.transform.position = new Vector3(2.32f, 0.58f, -0.72f);
                death.PlayerDeath();
                int life = playerStatus.Ball;
                lifePanel.UpdateBallPoint(life);
                Debug.Log("残機数　" + playerStatus.Ball);
                eventID = -1;
                break;
        }
	}

    public void EventIDSetter(int id)
    {
        eventID = id;
    }

    public void ColSetter(Collision col)
    {
        eventCol = col;
    }

    public void ObjSetter(GameObject obj)
    {
        eventObj = obj;
    }

    //濱口追記-----------------------------------------------------------------------------------------------
    //ファンガスイベントが終わった時に呼び出される処理
    public void endFungusEvent()
    {
        Debug.Log("ファンガスイベント終了を検知");

        //疑似ポーズ解除や他の処理呼び出しなど
    }
}
