using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamaTest01 : MonoBehaviour {

    public Vector3 pos;

	void Update () {
        transform.Translate(pos * Time.deltaTime);
	}
}
