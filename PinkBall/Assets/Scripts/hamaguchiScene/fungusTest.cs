using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fungusTest : GimicBase
{
    public fungusTest_MNG fMNG;


    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);


        Debug.Log("ファンガス呼び出しテスト");

        //ファンガス呼び出しメソッドを呼び出し
        fMNG.callFungus();

    }


}
