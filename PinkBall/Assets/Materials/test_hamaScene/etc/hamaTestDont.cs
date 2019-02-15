using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hamaTestDont : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(gameObject);
    }

    //呼ばれた時に自身を破棄する
    public void thisDestroy()
    {
        Destroy(gameObject);
    }
}
