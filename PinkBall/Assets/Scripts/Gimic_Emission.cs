using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimic_Emission : GimicBase {

    public Renderer renderer;
    public Color OffClor; //光っていない時の色
    public Color OnColor; //光った時の色
    public float emissionTime; //光っている時間

    public override void OnCollisionEnter(Collision col)
    {
        //GimicBaseの基礎機能呼び出し
        base.OnCollisionEnter(col);

        //光らせる処理（コルーチン）呼び出し
        StartCoroutine(lightingEmission());
    }

    //光らせるコルーチン
    IEnumerator lightingEmission()
    {
        renderer.material.SetColor("_EmissionColor", OnColor); //この色にする
        yield return new WaitForSeconds(emissionTime);　//この秒数が経過したら
        renderer.material.SetColor("_EmissionColor", OffClor); //この色にする
    }

}
