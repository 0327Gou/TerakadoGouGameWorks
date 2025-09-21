/*
* ファイル：MagicDiffusion C#
* システム：拡散攻撃魔法の生成処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDiffusion : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float DelayTime;        // ディレイ時間
    float DelayTimer;       // ディレイ時間のタイマー

    [SerializeField]
    float DestroyTime;      // 消滅時間
    float DestroyTimer;     // 消滅時間のタイマー

    [SerializeField]
    float spreadAngle;      // 拡散角度

    [SerializeField]
    int nWay;               // なん方向に出すか

    [SerializeField]
    bool toPlayer;          // プレイヤーへ向くか

    [SerializeField]
    AudioClip magicSound;       // 魔法発生の音 

    [SerializeField]
    GameObject bulletPrefab;    // 弾のプレハブ

    bool CanLanch;              // 発射可能か

    AudioSource _as;        // オーディオソース
    GameObject player;      // プレイヤーのオブジェクト


    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    private void Start()
    {
        // 初期化
        CanLanch = true;
        DelayTimer = 0.0f;
        DestroyTimer = 0.0f;

        // コンポーネントの取得
        _as = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // 発射可能なら処理
        if (CanLanch)
        {
            // プレイヤーにいっていいなら処理
            if (toPlayer)
            {
                // プレイヤーのほうを向く
                transform.rotation = RotateTarget(player);
            }

            // ディレイ時間の計測
            DelayTimer += Time.deltaTime;

             // ディレイタイムを超えたら処理
            if (DelayTimer > DelayTime)
            {
                // 弾一つ分の角度
                float oneSpreadAngle = spreadAngle / (nWay - 1);

                // 発射音を鳴らす
                _as.PlayOneShot(magicSound);

                // 設定した個数発射
                for (int i = 0; i < nWay; ++i)
                {
                    // 角度をずらす
                    float Angle = (oneSpreadAngle * i) - (spreadAngle / 2);

                    Quaternion rot = transform.rotation * Quaternion.Euler(0,0, Angle);

                    // オブジェクトを生成
                    Instantiate(bulletPrefab, transform.position, rot);
                }

                // リセット
                CanLanch = false;
                DelayTimer = 0;
            }
        }
        else
        {
            // 消滅までの時間の計測
            DestroyTimer += Time.deltaTime;

            // 消滅時間以上なら処理
            if (DestroyTimer > DestroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
