using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        playerStatus.Ball -= 1;
    }
}
