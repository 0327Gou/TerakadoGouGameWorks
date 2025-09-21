/*
* ファイル：MagicShield C#
* システム：シールド魔法を生成、破棄するスクリプト
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float destroyTime;          // 消滅時間
    float destroyTimer;         // 消滅時間のタイマー

    [SerializeField]
    GameObject shieldPrefab;    // シールドのプレハブ

    [SerializeField]
    string targetTag;           // ターゲットのタグ

    bool canLanch;              // 発射可能かのフラグ

    GameObject targetObj;       // ターゲットオブジェクト


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    private void Start()
    {
        // 初期化
        destroyTimer = 0.0f;
        canLanch = true;

        // タグからゲームオブジェクトを取得
        targetObj = GameObject.FindWithTag(targetTag);
    }

    // 毎フレームの処理
    private void Update()
    {
        // ターゲットの位置へ移動
        transform.position = targetObj.transform.position;

        // 発射可能なら処理
        if (canLanch)
        {
            // 自身の位置にシールドプレハブを子オブジェクトとして生成
            GameObject childObject = Instantiate(shieldPrefab, transform.position, Quaternion.identity);

            // 発射を停止
            canLanch = false;
        }
        else
        {
            // 時間が来たら消える処理
            // 時間を計測
            destroyTimer += Time.deltaTime;

            // 消滅時間を超えていたら処理
            if (destroyTimer > destroyTime)
            {
                // オブジェクトを消滅
                Destroy(gameObject);
            }
        }
    }
}