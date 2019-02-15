using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyFungus : MonoBehaviour {

	void Start () {
        DontDestroyOnLoad(gameObject);
        Debug.Log("ドントデストロイ設定完了");
    }

}
