using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : GimicBase 
{
    /// <summary>
    /// Warp ball .
    /// 動作確認はまだです。
    /// </summary>

    public enum WarpBallState
    {
        normal,
        goToWarpPoint,
    };

    public GameObject ball; // 

    private WarpBallState state;
    private Vector3 velocity = Vector3.zero;
    private InstantiateParticle instantiateParticle;

    public Transform startPosition; // 転送元
    public Transform destination; // 転送先

    public float goToWaitPointSpeed;


    // Use this for initialization
    void Start ()
    {
        state = WarpBallState.normal;
        instantiateParticle = GetComponent<InstantiateParticle>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (state == WarpBallState.goToWarpPoint)
        {
            GoToWarpWaitPoint();
        }
    }


    void GoToWarpWaitPoint()
    {
        if (Vector3.Distance(transform.position, startPosition.position) > 0.1f
        || Quaternion.Angle(transform.rotation, startPosition.rotation) >= 1f)
        {
            Debug.Log("移動中");
            transform.position = Vector3.Lerp(transform.position, startPosition.position, goToWaitPointSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, startPosition.rotation, goToWaitPointSpeed * Time.deltaTime);
        }
        else if (transform.position != startPosition.position)
        {
            Debug.Log("きっちり位置と角度を合わせる");
            transform.position = startPosition.position;
            transform.rotation = startPosition.rotation;
            //　ワープ用パーティクルの表示
            instantiateParticle.InstantiateWarpParticle(transform.position);
            //　0.5秒後にワープ
            Invoke("WarpDestination", 0.5f);
        }
    }

    // ワープさせる処理
    void WarpDestination()
    {
        transform.position = destination.position; //
        transform.rotation = destination.rotation; // 
        instantiateParticle.InstantiateWarpParticle(transform.position); //　移動先でワープパーティクルの表示
        SetState(WarpBallState.normal); // stateの変更
    }

    // state の変更
    public void SetState(WarpBallState state, Transform waitPoint = null, Transform warpPoint = null)
    {
        this.state = state;
        startPosition = waitPoint;
        destination = warpPoint;
        if (state == WarpBallState.goToWarpPoint)
        {
            velocity = Vector3.zero;
        }
    }
}

// ワープ先を設定する
public class WarpArea : MonoBehaviour
{
    public Transform warpPoint; // 

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            // ballの状態をワープに変更
            other.GetComponent<Warp>().SetState(
                Warp.WarpBallState.goToWarpPoint,
                transform,
                warpPoint);
        }
    }
}

// パーティクルをインスタンス化
public class InstantiateParticle : MonoBehaviour
{
    public GameObject warpParticle;

    public void InstantiateWarpParticle(Vector3 pos)
    {
        Instantiate(warpParticle, pos, Quaternion.Euler(0f, 0f, 0f));
    }
}

// パーティクルを自動で削除する
public class DeleteParticle : MonoBehaviour
{
    public ParticleSystem destroyParticles; // パーティクルを指定
    // Use this for initialization
    void Start()
    {
        destroyParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // パーティクルの再生が止まったらパーティクルを削除する
        if (destroyParticles.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
