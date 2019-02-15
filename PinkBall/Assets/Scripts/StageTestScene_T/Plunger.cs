using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Plunger : GimicBase
{
    /// <summary>
    /// 引っ張って飛ばすやつです。canvasでsliderを追加して下さい
    /// </summary>
    List<Rigidbody> ballList; // 球がPlungerTriggerに入ってくると追加する

    float power; // 出力する値を格納
    float minPower　= 0f; // 出力する値の最小値 = 0

    public float increase = 50f; // 出力する値を増やす値
    public float maxPower = 100f; // 出力する最大値
    public Slider powerSlider; // UIのスライダー表示

    bool ballReady; // 球がセットされているか確認

	void Start ()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();
    }
	
	void Update ()
    {
        // ボールのセットが出来たらsliderを表示
        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }

        // sliderに現在の出力する値を入力
        powerSlider.value = power;

        // ballがPlungerにセットされている場合
        if (ballList.Count > 0)
        {
            ballReady = true;

            // 左クリックで出力値を溜める
            if (Input.GetMouseButton(0))
            {
                if (power <= maxPower)
                {
                    power += increase * Time.deltaTime;
                }
            }

            // 左クリックを離すと溜めた出力値をAddForce
            if (Input.GetMouseButtonUp(0))
            {
                foreach(Rigidbody rb in ballList)
                {
                    rb.AddForce(power * Vector3.up, ForceMode.Impulse);
                }
            }
        }
        else
        {
            ballReady = false;
            power = minPower;
        }
    }

    // コライダーで対象のRigidBodyを取得し、ListにAdd、List内の要素数でballReadyを変更
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            ballList.Add(other.gameObject.gameObject.GetComponent<Rigidbody>());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            ballList.Remove(other.gameObject.gameObject.GetComponent<Rigidbody>());
            power = minPower;
        }
    }
}
