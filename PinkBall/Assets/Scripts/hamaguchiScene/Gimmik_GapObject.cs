﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmik_GapObject : GimicBase {

    //このオブジェクトの間を通過した時
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("通過");
    }


}