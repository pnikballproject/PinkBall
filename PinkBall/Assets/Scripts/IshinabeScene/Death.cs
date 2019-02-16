using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : GimicBase
{
    public PlayerStatus playerStatus;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayerDeath()
    {
        Debug.Log("ballを1;減らす");
        playerStatus.Ball +=  -1;
        if (playerStatus.Ball == 0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
