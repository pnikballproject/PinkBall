using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    const int StartCount = 0;

    public int DefaultBallPoint = 3; // デフォルトの残機数

    public int ball; // 玉の残機数
    public int score; // プレイヤーのスコアを保存する
    public int selectedCharacter; // 選択したキャラクターID
    public int hitCounter; // キャラクターへのヒット数

    ScorePanel scorePanel;
    LifePanel lifePanel;

    // Use this for initialization
    void Start()
    {
        ball = DefaultBallPoint;
        score = StartCount;
        selectedCharacter = StartCount;
        hitCounter = StartCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // スコアの追加を行う
    public void UpdateScore(int ScorePoint)
    {
        score += ScorePoint; // スコアの追加
        scorePanel.ShowScore(score); // スコア表示を更新
    }

    // ボール（残機）の増減を行う
    public void LifePointUpDate(int managementBall)
    {
        // 残機数を増やす場合
        if (managementBall > 0)
        {
            // 上限より増やさない
            if (ball < DefaultBallPoint)
            {
                ball += managementBall; // 残機増加
                lifePanel.UpdateBallPoint(ball); // 表示の更新
            }
        }
        // 残機数を減らす場合
        else
        {
            if (ball > 0)
            {
                ball += managementBall; // 残機減少
                lifePanel.UpdateBallPoint(ball); // 表示の更新
            }
            else
            {
                // ゲームオーバー
            }
        }
    }
}
