/*
 * ファイル：EnemyMove C#
 * システム：敵の移動処理
 * Created by 寺門 冴羽
 * 2025年 一部変更
 */

using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //-------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float moveSpeed;       // 敵の移動スピード    
    [SerializeField] float moveTime;        // 自動で移動するまでの時間
    [SerializeField] Vector2[] position;    // 移動箇所の配列
    int moveCount;      // 移動カウント
    float moveTimer;    // 移動

    [SerializeField] GameObject magic;   // 移動時の攻撃プレハブ

    //-------------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //-------------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    void Start()
    {
        // 初期化
        moveTimer = 0;
    }

    // 毎フレームの処理
    void Update()
    {
        // 時間を計測
        moveTimer += Time.deltaTime;

        // 時間経過で次の場所に移動する
        if (moveTimer >= moveTime)
        {
            moveTimer = 0.0f;   // タイマーの初期化
            moveCount++;        // カウントの増加

            // 移動カウントが配列の数以上になったら
            if (moveCount >= position.Length)
            {
                moveCount = 0;      // カウントを0に戻す。自動的に最初のポジションを目指す。
            }

            // 移動前に自分の位置から攻撃する
            Instantiate(magic, transform.position, transform.rotation);
        }

        // 目標地点まで移動する
        transform.position = Vector3.MoveTowards(transform.position, position[moveCount], moveSpeed * Time.deltaTime);
    }
}
