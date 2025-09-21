/*
 * ファイル：EnemyBody C#
 * システム：敵の体の処理。プレイヤーが触れるとダメージを受ける
 * 
 * Created by 寺門 冴羽
 * 2025年 一部変更
 */

using UnityEngine;

public class EnemyBody : MyFunctions
{
    //-------------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //-------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] int damage;                    // ダメージ    
    [SerializeField] float damageDelayTime;         // ダメージのディレイ時間
    float damageDelayTimer;                         // ダメージのディレイ時間のタイマー

    //-------------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //-------------------------------------------------------------------------------------------------------------------------------

    // 当たっている間の処理
    private void OnTriggerStay2D(Collider2D collision)
    {
        // プレイヤーか判定
        if (collision.gameObject.tag == "Player")
        {
            // ダメージのディレイを計測
            damageDelayTimer += Time.deltaTime;

            // ディレイタイムを超えていたら
            if (damageDelayTimer >= damageDelayTime)
            {
                // HPを取得してプレイヤーにダメージを与える
                PlayerHP _HP = collision.GetComponent<PlayerHP>();
                _HP.AddDamage(damage);

                // タイマーをリセット
                damageDelayTimer = 0;
            }
        }
    }
}
