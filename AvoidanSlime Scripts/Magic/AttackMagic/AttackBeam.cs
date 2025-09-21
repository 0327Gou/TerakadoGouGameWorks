/*
* ファイル：AttackBeam C#
* システム：ビームの攻撃処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBeam : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------
        
    [SerializeField]
    int dps;    // 秒間ダメージ

    // 蓄積ダメージ
    float playerDamage;
    float enemyDamage;

    // ダメージを与えられるかどうか
    bool canDamagePlayer;
    bool canDamageEnemy;

    PlayerHP _playerHP;     // プレイヤーのHP
    EnemyHP _enemyHP;       // 敵のHP


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    private void Start()
    {
        // 初期化 
        playerDamage = 0.0f;
        enemyDamage = 0.0f;

        canDamageEnemy = false;
        canDamagePlayer = false;

        _enemyHP = null;
        _playerHP = null;
    }

    // 毎フレームの処理
    private void Update()
    {
        // 敵にダメージを与えられるなら処理する
        if (canDamageEnemy)
        {
            // DPS分加算
            enemyDamage += dps * Time.deltaTime;

            // 蓄積されたダメージが1を超えたら処理
            if (enemyDamage >= 1.0f)
            {
                // ダメージを消費する
                --enemyDamage;

                // ダメージを与える                
                _enemyHP.AddDamage(1);
            }
        }

        // プレイヤーにダメージを与えられるなら処理する
        if (canDamagePlayer)
        {
            // DPS分加算
            playerDamage += dps * Time.deltaTime;

            // 蓄積されたダメージが1を超えたら処理
            if (playerDamage >= 1.0f)
            {
                // ダメージを消費する
                --playerDamage;

                // ダメージを与える
                _playerHP.AddDamage(1);
            }
        }
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //----------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // タグが敵なら処理する
        if (collision.gameObject.tag == "Enemy")
        {
            // 敵のHPを取得
            _enemyHP = collision.GetComponent<EnemyHP>();
            
            // 取得できてれば処理
            if (_enemyHP != null)
            {
                // ダメージを許可
                canDamageEnemy = true;
            }
            else
            {
                // 敵がないと出力
                Debug.LogError("AttackBeam : Enemy null");
            }
        }

        // プレイヤーへのダメージ
        if (collision.gameObject.tag == "Player")
        {
            // プレイヤーのHPを取得
            _playerHP = collision.GetComponent<PlayerHP>();

            // 取得できていれば処理
            if (_playerHP != null)
            {
                // プレイヤーへのダメージを許可
                canDamagePlayer = true;
            }
            else
            {
                Debug.LogError("AttackBeam：Player null");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 敵のタグを判定
        if (collision.gameObject.tag == "Enemy")
        {
            // ダメージを却下する
            canDamagePlayer = false;
        }

        // プレイヤーのタグを判定
        if (collision.gameObject.tag == "Player")
        {
            // ダメージを却下
            canDamagePlayer = false;
        }
    }

}
