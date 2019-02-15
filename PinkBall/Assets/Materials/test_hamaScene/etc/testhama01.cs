using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class testhama01 : MonoBehaviour {

    public GameObject panel;

	void Start () {
        StartCoroutine(PanelReTransmission());
	}

    IEnumerator PanelReTransmission()
    {
        Image image = panel.GetComponent<Image>();

        for (float i = 255.0f; i >= 0.0f; i--)
        {
            i -= 3;
            image.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

        StartCoroutine(stay());
    }

    IEnumerator stay()
    {
        yield return new WaitForSeconds(3.0f);

        StartCoroutine(PanelTransmission());
    }



    IEnumerator PanelTransmission()
    {
        Image image = panel.GetComponent<Image>();

        for (float i = 0.0f; i <= 255.0f; i++)
        {
            i += 3;
            image.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

        SceneManager.LoadScene("test2_hama");

    }


}
