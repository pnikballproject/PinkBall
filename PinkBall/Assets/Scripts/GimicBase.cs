using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicBase : MonoBehaviour{

    //このオブジェクトのID
    public int id;

    //このオブジェクトに当たった時の得点
    public int gainScore;

    //反発力 10000くらい～　じゃないとちゃんと弾かない 玉の設定にもよるので調整してください
    public float resilience;

    //反発方向
    Vector3 direction;

    //管理マネージャー インスペクタで設定する必要あり
    public Manager mng;

    //プロパティ類------------------------------------------------

    //スコアのプロパティ　使わないかもしれないが一応
    public int GainScore
    {
        get
        {
            return gainScore;
        }

        set
        {
            gainScore = value;
        }
    }

    //------------------------------------------------------------

    //玉がこのオブジェクトに当たった時
    public void OnCollisionEnter(Collision other)
    {
        //マネージャーに自身のIDを渡す
        //ギミック制作者は自身のシーンでオブジェクト作成する際に、このメソッドをコメントアウトしてください
        //ここを設定しないとnullでちゃいますん
        //ステージ作成者はここをコメントアウトせずに使用してください。
        //mng.EventIDSetter(id);

        Debug.Log("ギミックオブジェクトID:" + id + " にヒット");

        //方向を算出する処理呼び出し
        checkDirection(other);
    }

    //反発方向を算出
    public void checkDirection(Collision other)
    {
        direction = other.gameObject.transform.position - transform.position;

        addForce(other);
    }

    //玉を反発させる力を加える
    public void addForce(Collision other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce((direction.normalized) * resilience * Time.deltaTime);
    }

}