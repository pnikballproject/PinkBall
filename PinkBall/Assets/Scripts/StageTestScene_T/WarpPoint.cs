using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : GimicBase
{
    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        // 指定のGameObjectに転移させる
        other.gameObject.transform.position = new Vector3(
            target.transform.position.x,
            target.transform.position.y,
            target.transform.position.z
            );
    }
}
