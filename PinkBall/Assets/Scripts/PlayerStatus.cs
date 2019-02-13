using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    const int StartCount = 0;
    public int DefaultBallPoint = 3; // デフォルトの残機数

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
            if(value > 0)
            {
                if(DefaultBallPoint > ball)
                {
                    ball += value;
                }
            }
            else
            {
                ball += value;
            }
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
            hitCounter = value;
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
