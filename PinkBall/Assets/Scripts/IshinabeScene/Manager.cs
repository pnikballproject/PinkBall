using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    public GameObject[] gimmiks;
    public GameObject ballObj;
    public GameObject gateObj;
    public int eventID = -1;
    public PlayerStatus playerStatus;
    public ScorePanel scorePanel;
    public LifePanel lifePanel;
    public TalkEventController talkEventController;
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
                ballObj.transform.position = new Vector3(3.56f, 0.58f, -0.72f);
                death.PlayerDeath();
                death.hitBasicProcessing(eventCol);
                int life = playerStatus.Ball;
                lifePanel.UpdateBallPoint(life);
                Debug.Log("残機数　" + playerStatus.Ball);
                if(playerStatus.Ball == 0)
                {
                    SceneManager.LoadScene("Result");
                }
                eventID = -1;
                break;

            //Hinder
            case 3:
                Hinder hinder = eventObj.GetComponent<Hinder>();
                hinder.hitBasicProcessing(eventCol);
                playerStatus.Score = hinder.GainScore;
                point = playerStatus.Score;
                scorePanel.ShowScore(point);
                eventID = -1;
                break;
            
            //Gateをtrueに
            case 4:
                Gimic_Emission emission2 = eventObj.GetComponent<Gimic_Emission>();
                emission2.Emission();
                emission2.hitBasicProcessing(eventCol);
                playerStatus.Score = emission2.GainScore;
                point = playerStatus.Score;
                scorePanel.ShowScore(point);
                gateObj.SetActive(true);
                eventID = -1;
                break;

            //Gate
            case 5:
                Debug.Log("case5");
                Rigidbody ballRigidbody = ballObj.GetComponent<Rigidbody>();
                ballRigidbody.isKinematic = true;
                GimicBase gimicBase = eventObj.GetComponent<GimicBase>();
                playerStatus.Score = gimicBase.GainScore;
                playerStatus.HitCounter += 1;
                talkEventController.toStartFungusTalkEvent(playerStatus.HitCounter);
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
        Rigidbody ballRigidbody = ballObj.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = false;
        //疑似ポーズ解除や他の処理呼び出しなど
    }
}
