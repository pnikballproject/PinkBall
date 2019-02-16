using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    const int StartCount = 0;

    private int defaultBallPoint; // 残機の初期化
    private int ball; // 玉の残機数
    private int score; // プレイヤーのスコアを保存する
    private int selectedCharacter; // 選択したキャラクターID
    private int hitCounter; // キャラクターへのヒット数

    public int Ball
    {
        get
        {
            return ball;
        }

        set
        {
            Debug.Log("デバッグ呼び出され");
            //if (value > 0)
            //{
            //    if(DefaultBallPoint > ball)
            //    {
            //        Debug.Log("デバッグ1;+");
            //        ball += value;
            //    }
            //}
            //else if(value == -1)
            //{
            //    Debug.Log("デバッグ1;-");
            //    ball += value;
            //}

            Debug.Log("デバッグ1;-");
            ball = value;

        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score += value;
        }
    }

    public int SelectedCharacter
    {
        get
        {
            return selectedCharacter;
        }

        set
        {
            selectedCharacter = value;
        }
    }

    public int HitCounter
    {
        get
        {
            return hitCounter;
        }

        set
        {
            if (hitCounter <= 3) //ヒット回数が3以上ならば
            {
                return; //以下の処理はせずに抜ける
            }
            hitCounter = value;
        }
    }

    public int DefaultBallPoint
    {
        get
        {
            return defaultBallPoint;
        }

        set
        {
            defaultBallPoint = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        ball = DefaultBallPoint;
        score = StartCount;
        selectedCharacter = StartCount;
        hitCounter = StartCount;
    }
}
