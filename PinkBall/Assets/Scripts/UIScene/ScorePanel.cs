using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public Text scoreLabel;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // スコアの表示
    public void ShowScore(int score)
    {
        // 渡されたポイントを表示します
        scoreLabel.text = "Score:" + score;
    }
}
