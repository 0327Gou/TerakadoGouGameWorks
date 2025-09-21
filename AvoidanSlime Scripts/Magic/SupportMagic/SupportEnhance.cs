/*
* ファイル：SupportEnhance C#
* システム：強化魔法の処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportEnhance : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float m_destroyTime;        // 消滅時間
    float m_destroyTimer;       // 消滅時間のタイマー

    [SerializeField]
    AudioClip enhanceSound;     // エンハンスのダメージアップ音
    
    AudioSource _as;            // オーディオソース


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    void Start()
    {
        // 初期化
        m_destroyTimer = 0.0f;

        // コンポーネントの取得
        _as = GetComponent<AudioSource>();
    }

    // 毎フレームの処理
    void Update()
    {
        // 消滅時間を計測
        m_destroyTimer += Time.deltaTime;

        // 時間を超えたら
        if (m_destroyTimer > m_destroyTime)
        {
            // オブジェクトを消去
            Destroy(gameObject);
        }
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //----------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // タグがBulletかEnemyBulletなら処理
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            // 攻撃力をあげる
            collision.GetComponent<Attack>().Enhance();

            // 効果アップの効果音を鳴らす
            _as.PlayOneShot(enhanceSound);
        }
    }
}
