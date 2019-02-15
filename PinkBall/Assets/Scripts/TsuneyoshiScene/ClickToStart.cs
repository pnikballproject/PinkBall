using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToStart : MonoBehaviour {

    float time;
    public Text text;

    private void Start()
    {
        StartCoroutine(blink());
    }

    IEnumerator blink()
    {
        for (float i = 0.0f; i <= 250.0f; i++)
        {
            i += 17;
            text.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);
        }

        StartCoroutine(blink2());
    }

    IEnumerator blink2()
    {

        for (float i = 255.0f; i >= 0.0f; i--)
        {
            i -= 18;
            text.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);
        }

        StartCoroutine(blink());
    }
}
