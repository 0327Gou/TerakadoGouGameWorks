/*
* ファイル：Magic C#
* システム：単発攻撃魔法の制御
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MyFunctions
{
    [SerializeField]
    float delayTime;        // 発射までの猶予時間
    float delayTimer;       // 発射までのタイマー

    [SerializeField]
    float destroyTime;      // 消滅までの時間
    float destroyTimer;     // 消滅までのタイマー

    [SerializeField]
    GameObject obj;         // 弾のプレハブ

    [SerializeField]
    AudioClip magicSound;   // 魔法発生の音

    bool CanLanch;          // 発射許可

    AudioSource _as;        // オーディオソース
    GameObject player;      // プレイヤー格納用


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    private void Start()
    {
        // 初期化
        CanLanch = true;
        delayTimer = 0.0f;
        destroyTimer = 0.0f;

        // コンポーネントの取得
        _as = GetComponent<AudioSource>();

        // プレイヤーを取得
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (CanLanch)
        {
            // プレイヤーのほうを向く
            transform.rotation = RotateTarget(player);

            // ディレイを計測
            delayTimer += Time.deltaTime;

            // ディレイ時間を超えていたら処理
            if (delayTimer > delayTime)
            {
                // 発射音を鳴らす
                _as.PlayOneShot(magicSound);

                // 発射
                Instantiate(obj, transform.position, transform.rotation);

                // 発射を停止
                CanLanch = false;
            }
        }
        else
        {
            // 消滅時間を計測
            destroyTimer += Time.deltaTime;
            
            // 消滅時間を超えていたら消滅
            if (destroyTimer > destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}