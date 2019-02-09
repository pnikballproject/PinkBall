using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject[] gimmiks;
    public int eventID = -1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        switch (eventID)
        {
            case 0:
                /*
                Hoge hoge = gimmiks[0].GetComponent<Hoge>();
                hoge.Event();
                eventID = -1;
                 */
                break;
        }
	}

    public void EventIDSetter(int id)
    {
        eventID = id;
    }
}
