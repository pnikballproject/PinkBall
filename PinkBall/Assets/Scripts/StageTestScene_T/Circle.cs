using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public float speed;
    public float radius;
    public float yPosition;

    // Update is called once per frame
    void Update()
    {
        float x = radius * Mathf.Sin(Time.time * speed);
        float y = yPosition;
        float z = radius * Mathf.Cos(Time.time * speed);

        transform.position = new Vector3(x, y, z);
    }
}
