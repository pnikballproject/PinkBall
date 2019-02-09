using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    public GameObject[] ballIcons; // ボールのアイコンを指定
    public GameObject[] grayOutBallIcons; // グレーアウトのアイコンを指定

	// Use this for initialization
	void Start ()
    {
        foreach(var alive in ballIcons)
        {
            alive.SetActive(true);
        }
		foreach(var grayOut in grayOutBallIcons)
        {
            grayOut.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // 残機の表示を行います。
    public void UpdateBallPoint(int life)
    {
        for(int i = 0; i < ballIcons.Length; i++)
        {
            if (i < life)
            {
                ballIcons[i].SetActive(true);
                grayOutBallIcons[i].SetActive(false);
            }
            else
            {
                ballIcons[i].SetActive(false);
                grayOutBallIcons[i].SetActive(true);
            }
        }
    }
}
