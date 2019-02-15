using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hamatest02 : MonoBehaviour {

    public GameObject panel;
    public Image image;

    private void Start()
    {
         Debug.Log("スタート");
        StartCoroutine(PanelTransmission());       
    }

    IEnumerator PanelTransmission()
    {
        image = panel.GetComponent<Image>();

        for (float i = 255.0f; i >= 80.0f; i--)
        {
            i -= 2; //4倍速
            image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

    }
}
