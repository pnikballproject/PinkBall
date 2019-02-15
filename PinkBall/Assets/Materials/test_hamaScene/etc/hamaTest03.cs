using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hamaTest03 : MonoBehaviour {

    //テキスト系
    public Text TeamNameText;
    public GameObject textPanel;
    public Image teamImage;

    //フェード系
    public GameObject panel;
    public GameObject panel2;
    public Image image;

    //タイトル
    public GameObject titlePanel;
    public Text[] texts;

    //シルエット
    public SpriteRenderer charaRenderer;

    //玉
    public SpriteRenderer[] tamas;

    //スタッフクレジット
    public Text[] stuffText;

    public float time;

    bool flag1;
    bool flag2;
    bool flag3;
    bool flag4;
    bool textFlag;
    bool flag5;
    bool Titleflag;
    bool flag6;
    bool flag7;
    bool flag8;
    bool flag9;
    bool flag10;
    bool flag11;

    private void Start()
    {
        image = panel.GetComponent<Image>();
        StartCoroutine(PanelTransmission());
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (flag8 == false)
        {
            if (time >= 1.5f)
            {
                stuffText[5].gameObject.SetActive(true);
                stuffText[8].gameObject.SetActive(true);

            }
        }
        if (flag1 == false)
        {
            if (time >= 4.1f)
            {
                flag1 = true;
                //time = 0f;
                movePos();
            }
        }
        if (flag9 == false)
        {
            if (time >= 6.0f)
            {
                stuffText[5].gameObject.SetActive(false);
                stuffText[8].gameObject.SetActive(false);

            }
        }

        if (flag2 == false)
        {
            if (time >= 6.35f)
            {
                flag2 = true;
                movePos2();

                stuffText[6].gameObject.SetActive(true);
                stuffText[7].gameObject.SetActive(true);
            }
        }

        if (flag3 == false)
        {
            if (time >= 8.0f)
            {
                flag3 = true;
                movePos3();
            }
        }
        if (flag4 == false)
        {
            if (time >= 8.4f)
            {
                flag4 = true;
                movePos4();
            }
        }
        if (flag10 == false)
        {
            if (time >= 9.2f)
            {
                stuffText[7].gameObject.SetActive(false);
                stuffText[6].gameObject.SetActive(false);
            }
        }
        if (textFlag == false)
        {
            if (time >= 9.5f)
            {
                textFlag = true;
                OnSetActiveText();

            }
        }
        if (flag5 == false)
        {
            if (time >= 12.0f)
            {
                flag5 = true;
                StartCoroutine(PanelReTransmission());
                StartCoroutine(textReTransmission());
                changeTamaColor();
            }
        }
        if (Titleflag == false)
        {
            if (time >= 14.0f)
            {
                Titleflag = true;
                StartCoroutine(titlePanelSetActive());
                StartCoroutine(characterReTransmission());

                stuffText[2].gameObject.SetActive(true);
                stuffText[4].gameObject.SetActive(true);

            }
        }
        if (flag11 == false)
        {
            if (time >= 18.5f)
            {
                stuffText[2].gameObject.SetActive(false);
                stuffText[4].gameObject.SetActive(false);

                stuffText[1].gameObject.SetActive(true);
            }
        }
        if (flag6 == false)
        {
            if (time >= 19.0f)
            {
                flag6 = true;
                StartCoroutine(PanelReTransmission2());
            }

        }
        if (flag7 == false)
        {
            if(time >= 22.6f)
            {
                flag7 = true;
                SceneManager.LoadScene("Title");
            }
        }

    }

    public void movePos()
    {
        Vector3 pos = transform.position;
        pos.x = 30;
        Vector3 newpos = new Vector3(pos.x, pos.y, 50);
        transform.position = newpos;
        Debug.Log("movePos");
        Debug.Log(transform.position);
    }

    public void movePos2()
    {
        Vector3 pos = transform.position;
        pos.x = 40;
        //pos.y = 20;
        Vector3 newpos = new Vector3(pos.x, pos.y, 50);
        transform.position = newpos;
        Debug.Log("movePos2");
        Debug.Log(transform.position);

    }

    public void movePos3()
    {
        Vector3 pos = transform.position;
        pos.x = 42;
        pos.y = 5;
        Vector3 newpos = new Vector3(pos.x, pos.y, 53);
        transform.position = newpos;
        Debug.Log("movePos3");
        Debug.Log(transform.position);

    }

    public void movePos4()
    {
        Vector3 pos = transform.position;
        pos.x = 52;
        pos.y = 25;
        Vector3 newpos = new Vector3(pos.x, pos.y, 50);
        transform.position = newpos;
        Debug.Log("movePos4");
        Debug.Log(transform.position);

    }

    public void OnSetActiveText()
    {
        textPanel.gameObject.SetActive(true);
        //teamImage = textPanel.GetComponent<Image>();

        StartCoroutine(textTransmission());
    }

    //チームテキスト浮き上がらせ
    IEnumerator textTransmission()
    {

        for (float i = 0.0f; i <= 250.0f; i++)
        {
            i += 4; //4倍速
            TeamNameText.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);
        }

    }

    //逆
    IEnumerator textReTransmission()
    {

        for (float i = 255.0f; i >= 0.0f; i--)
        {
            i -= 6; //4倍速
            TeamNameText.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);
        }        

    }



    //パネル透過
    IEnumerator PanelTransmission()
    {
        for (float i = 255.0f; i >= 80.0f; i--)
        {
            i -= 2; //4倍速
            image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

    }

    //パネル曇らせる
    IEnumerator PanelReTransmission()
    {
        for (float i = 0.0f; i <= 150.0f; i++)
        {
            i += 6;
            image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

    }

    //続いてホワイトアウトさせる
    IEnumerator PanelReTransmission2()
    {
        Image panel2image = panel2.GetComponent<Image>();

        for (float i = 0.0f; i <= 255.0f; i++)
        {
            i += 2;
            panel2image.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

    }

    //シルエットを陰に
    IEnumerator characterReTransmission()
    {
        for (float i = 0.0f; i <= 248.0f; i++)
        {
            i += 5;
            charaRenderer.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, i / 255.0f);
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

    }

    //玉の色変更
    void changeTamaColor()
    {
        foreach (SpriteRenderer t in tamas)
        {
            t.color = new Color(255.0f / 255.0f, 0.0f / 255.0f, 142.0f / 255.0f, 255.0f / 255.0f);
        }
    }

    //タイトルパネルひょじ
    IEnumerator titlePanelSetActive()
    {
        titlePanel.SetActive(true);

        //Image titleImage = titlePanel.GetComponent<Image>();

        

        for (float i = 0.0f; i <= 200.0f; i++)
        {
            i += 4;
            foreach (Text t in texts)
            {
                t.color = new Color(255.0f / 255.0f, 0.0f / 255.0f, 142.0f / 255.0f, i / 255.0f);
            }
            Debug.Log(i);
            yield return new WaitForSeconds(0.04f);

        }

    }

}
