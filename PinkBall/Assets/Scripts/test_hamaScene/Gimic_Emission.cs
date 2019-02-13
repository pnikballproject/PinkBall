using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimic_Emission : GimicBase {

    public Renderer renderer;

    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);

        //renderer.material.SetColor("_EmissionColor", new Color(1, 0, 0));

        StartCoroutine(lightingEmission());


    }

    IEnumerator lightingEmission()
    {
        renderer.material.SetColor("_EmissionColor", new Color(1, 0, 0));
        yield return new WaitForSeconds(1f);
        renderer.material.SetColor("_EmissionColor", new Color(0, 0, 0));
    }

}
