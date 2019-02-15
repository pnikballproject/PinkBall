using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : GimicBase
{
    public Vector3 acceleratDirection;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(
            new Vector3(acceleratDirection.x, acceleratDirection.y, acceleratDirection.z), ForceMode.Impulse);
    }
}
