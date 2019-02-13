using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimicBase : MonoBehaviour{

    //このオブジェクトのID
    public int id;

    //このオブジェクトに当たった時の得点
    public int gainScore;

    //このオブジェクトに当たった時の効果音 必要分入れてください
    //配列の0番目は当たった時に自動で鳴る音を設定してください（その他駆動のイベント的音源は1番以降に）
    public AudioClip[] clip;

    //オーディオソース
    //自身にアタッチしたオーディオソースコンポーネントをインスペクター上で設定してください
    //オーディオソース側のオーディオクリップには何も入れなくていいです（↑で持っているため）
    public AudioSource hitSound;

    //反発力 10000くらい～　じゃないとちゃんと弾かない 玉の設定にもよるので調整してください
    public float resilience;

    //反発方向
    Vector3 direction;

    //管理マネージャー インスペクタで設定する必要あり
    public Manager mng;

    //プロパティ類------------------------------------------------

    //スコアのプロパティ　使わないかもしれないが一応
    public virtual int GainScore
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
    public virtual void OnCollisionEnter(Collision col)
    {
        //マネージャーに自身のIDを渡す
        //ギミック制作者は自身のシーンでオブジェクト作成する際に、このメソッドをコメントアウトしてください
        //ここを設定しないとnullでちゃいますん
        //ステージ作成者はここをコメントアウトせずに使用してください。
        //mng.EventIDSetter(id);

        Debug.Log("ギミックオブジェクトID:" + id + " にヒット");

        //※デバッグ用です　本番ではコメントアウトしてください
        //ギミック制作シーン（マネージャがない状態）で制作デバッグ用です
        //基本的な処理をすべて呼び出します
        hitBasicProcessing(col);
    }

    //基本的なヒット時の処理1連を自動処理
    public virtual void hitBasicProcessing(Collision col)
    {
        //効果音を鳴らす
        playHitSoundClip(0); //基本ヒット時音

        //方向を算出して反発させる処理呼び出し
        checkDirection(col);
    }

    //基本効果音を鳴らす
    public virtual void playHitSoundClip(int num)
    {
        hitSound.PlayOneShot(clip[num]);
    }

    //反発方向を算出
    public virtual void checkDirection(Collision col)
    {
        direction = col.gameObject.transform.position - transform.position;

        addForce(col);
    }

    //玉を反発させる力を加える
    public virtual void addForce(Collision col)
    {
        col.gameObject.GetComponent<Rigidbody>().AddForce((direction.normalized) * resilience * Time.deltaTime);
    }

}