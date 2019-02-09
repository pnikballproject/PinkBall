using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicBase : MonoBehaviour {

    //このオブジェクトのID
    public int id;

    //反発力 500倍以上くらいじゃないとちゃんと弾かない
    public float resilience;

    //管理マネージャー ←ここを管理クラスのクラス型にしてインスペクターで設定
    public GameObject mng;

    //玉がこのオブジェクトに当たった時
    public void OnCollisionEnter(Collision other)
    {
        //マネージャー側のIDを受け付けるメソッドに値を渡す
        //mng 

        //デバッグ　玉を反発させる
        addForce(other);
    }

    //ギミック自体
    public void Gimic()
    {
        //このギミックの挙動
    }

    //デバッグ　玉に算出したベクトル方向の力を加える
    public void addForce(Collision other)
    {
        Debug.Log("addForceメソッド呼び出され");

        //other.gameObject.GetComponent<Rigidbody>().AddForce(-(direction.normalized) * resilience);

        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * resilience);
    }

}
