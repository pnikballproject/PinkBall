using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipController : MonoBehaviour {

    /*
	 * 変数の提議
	*/
    //public GameObject ball; // ボールのゲームオブジェクト 
    //private Rigidbody ballRb;// ボールのリジッドボディー
    float pinPower; // ピンの弾く力

    float angle = 20f; //ピンボール版の傾き

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


    // 画面が生成（表示）されるときに呼ばれます
    void Start()
    {

        /*
		 * 変数の初期化
		*/

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
        // フリッパー制御よう変数
        LFlipperTF = false;
        RFlipperTF = false;


    }

    // 画面が更新される各フレームごとによばれます
    void Update()
    {

        // リターン(Return)キーをクリックすると
        if (Input.GetKeyUp(KeyCode.Return))
        {

            Debug.Log("x,y=" + xVector(angle) + "," + yVector(angle));

            // ピンボール台の傾き（20度）に合わせたベクトルを計算
            Vector3 Pos1 = new Vector3(xVector(angle), yVector(angle), 0f);
            // ボールに力を加える
            //ballRb.AddForce(Pos1 * pinPower * 105f);
        }

        // ピンボールに
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LFlipperTF = true;
            openFlipper(LFlipperTF, RFlipperTF);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RFlipperTF = true;
            openFlipper(LFlipperTF, RFlipperTF);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            LFlipperTF = false;
            RFlipperTF = false;
            closeFlipper();
        }

    }

    /*
	 * フリッパー オープン制御メソッド
	*/
    public void openFlipper(bool LF, bool RF)
    {

        if (RF)
        {
            JointSpring sprR = hjR.spring;
            sprR.spring = springR;
            sprR.damper = damperR;
            sprR.targetPosition = openAngleR;
            hjR.spring = sprR;
            Debug.Log("FlipperR:" + openAngleR);
        }

        if (LF)
        {
            JointSpring sprL = hjL.spring;
            sprL.spring = springL;
            sprL.damper = damperL;
            sprL.targetPosition = openAngleL;
            hjL.spring = sprL;
            Debug.Log("FlipperL" + openAngleL);
        }
    }

    /*
	 * フリッパー クローズ制御メソッド
	*/
    public void closeFlipper()
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

    /*
	* 練習のためのメソッド化しています。
	* 頻繁に使うわけでもないので練習でなければ必要はないかもしれません
	*/
    // private メソッドは同じクラス内でのみ呼び出せる
    // メソッドからの値を取得したい場合は、「型」の宣言と「return」文による返り値の指定が必要です。
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
