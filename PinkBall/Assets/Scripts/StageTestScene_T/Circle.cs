using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float speed;
    public float radius;
    public float posZ = -0.5f;

    // Update is called once per frame
    void Update()
    {
        float x = radius * Mathf.Sin(Time.time * speed);
        float y = radius * Mathf.Cos(Time.time * speed);

        transform.localPosition = new Vector3(x, y, posZ);
    }
}
