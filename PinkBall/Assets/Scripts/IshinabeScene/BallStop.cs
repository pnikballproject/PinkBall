using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour {
    public GameObject ball;
    Rigidbody r;

	// Use this for initialization
	void Start () {
        r = ball.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("q"))
        {
            if (r.isKinematic == true)
            {
                r.isKinematic = false;
            }
            else
            {
                r.isKinematic = true;
            }
        }
        
	}
}
