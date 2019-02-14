using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : GimicBase
{
    public Vector3 accelerationDirection;

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(
            new Vector3(accelerationDirection.x, accelerationDirection.y, accelerationDirection.z), ForceMode.Impulse);
    }
}
