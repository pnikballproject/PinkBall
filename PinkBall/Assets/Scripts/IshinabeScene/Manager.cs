using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject[] gimmiks;
    public int eventID = -1;
    public PlayerStatus playerStatus;
    public ScorePanel scorePanel;
    public LifePanel lifePanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (eventID)
        {
            case 0:
                Gimic_Emission emission = gimmiks[0].GetComponent<Gimic_Emission>();
                emission.Emission();
                playerStatus.Score = emission.GainScore;
                int point = playerStatus.Score;
                scorePanel.ShowScore(point);
                eventID = -1;
                break;
        }
	}

    public void EventIDSetter(int id)
    {
        eventID = id;
    }
}
