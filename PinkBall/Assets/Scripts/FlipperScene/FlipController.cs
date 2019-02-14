using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour
{
    //public GameObject ball; // ボールのゲームオブジェクト 
    //private Rigidbody ballRb;// ボールのリジッドボディー
    float pinPower; // ピンの弾く力

    public float stageAngle = 20f; // Stageの傾き

    // 右フリッパー
    public GameObject RightFlipper; // 右フリッパーゲームオブジェクト
    public float springR; // スプリングの強さ （右）
    public float damperR; // 戻る力 （）
    public float openAngleR; // 左
    public float closeAngleR;
    private HingeJoint hjR;

    // 左フリッパー
    public GameObject LeftFlipper;
    public float springL;
    public float damperL;
    public float openAngleL;
    public float closeAngleL;
    private HingeJoint hjL;

    // フリッパー制御用
    bool LFlipperTF, RFlipperTF;

    void Start()
    {
        // ボール
        //ball.transform.position = new Vector3(0.268f, 0.025f, -0.87f);  // ピンOBJの初期化
        //ballRb = ball.GetComponent<Rigidbody>();    // ボールのリジッドボディーを格納
        pinPower = 5f;  // 弾きの強さを初期化

        // 右フリッパー
        hjR = RightFlipper.GetComponent<HingeJoint>();
        JointLimits limitsR = hjR.limits;
        limitsR.max = openAngleR;
        limitsR.min = closeAngleR;
        hjR.limits = limitsR;
        hjR.useLimits = true;

        // 左フリッパー
        hjL = LeftFlipper.GetComponent<HingeJoint>();
        JointLimits limitsL = hjL.limits;
        limitsL.max = openAngleL;
        limitsL.min = closeAngleL;
        hjL.limits = limitsL;
        hjL.useLimits = true;

        // フリッパー制御
        LFlipperTF = false;
        RFlipperTF = false;
    }

    void Update()
    {
        // リターン(Return)キーをクリックした時
        if (Input.GetKeyUp(KeyCode.Return))
        {
            // ピンボール台の傾きに合わせたベクトルを計算
            Vector3 Pos1 = new Vector3(xVector(stageAngle), yVector(stageAngle), 0f);

            // ボールに力を加える
            //ballRb.AddForce(Pos1 * pinPower * 105f);
        }

        // 左フリッパーの操作
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LFlipperTF = true;
            OpenFlipper(LFlipperTF, RFlipperTF);
        }

        // 右フリッパーの操作
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RFlipperTF = true;
            OpenFlipper(LFlipperTF, RFlipperTF);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            LFlipperTF = false;
            RFlipperTF = false;
            CloseFlipper();
        }

    }

    // フリッパー オープン制御メソッド
    public void OpenFlipper(bool LF, bool RF)
    {

        if (RF)
        {
            JointSpring sprR = hjR.spring;
            sprR.spring = springR;
            sprR.damper = damperR;
            sprR.targetPosition = openAngleR;
            hjR.spring = sprR;
            //Debug.Log("FlipperR:" + openAngleR);
        }

        if (LF)
        {
            JointSpring sprL = hjL.spring;
            sprL.spring = springL;
            sprL.damper = damperL;
            sprL.targetPosition = openAngleL;
            hjL.spring = sprL;
            //Debug.Log("FlipperL" + openAngleL);
        }
    }

    // フリッパー クローズ制御メソッド
    public void CloseFlipper()
    {
        JointSpring sprR = hjR.spring;
        sprR.spring = springR;
        sprR.damper = damperR;
        sprR.targetPosition = closeAngleR;
        hjR.spring = sprR;

        JointSpring sprL = hjL.spring;
        sprL.spring = springL;
        sprL.damper = damperL;
        sprL.targetPosition = closeAngleL;
        hjL.spring = sprL;
    }

    private float yVector(float angle)
    {
        // 角度(angle)に対する、y軸のベクトルを計算します。
        float y = (float)Mathf.Sin(angle * (Mathf.PI / 180));
        return y;
    }

    private float xVector(float angle)
    {
        // 角度(angle)に対する、x軸のベクトルを計算します。
        float x = (float)Mathf.Cos(angle * (Mathf.PI / 180));
        return x;
    }
}
