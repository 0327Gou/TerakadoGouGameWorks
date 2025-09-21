/*
* ファイル：MagicBeam C#
* システム：ビーム魔法の制御
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBeam : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float aimTime;          // エイム時間

    [SerializeField]
    float delayTime;        // ディレイ時間
    float SumDelayTime;     // ディレイ時間のタイマー

    [SerializeField]
    float destroyTime;      // 消滅までの時間

    [SerializeField]
    GameObject beamPrefab;  // ビームプレハブ

    // マテリアル
    [SerializeField]
    Material aimMaterial;   // エイム中のマテリアル

    [SerializeField]
    Material beamMaterial;  // ビーム中のマテリアル

    bool canLanch;          // 発射許可
    bool canMaterialChange; // マテリアルの変更許可
    float objTimer;         // オブジェクトの生成からの時間

    SpriteRenderer _sr;     // スプライトレンダラー格納用
    GameObject player;      // プレイヤーのゲームオブジェクト格納用


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    private void Start()
    {
        // 初期化
        canLanch = true;
        canMaterialChange = true;
        objTimer = 0.0f;

        // ディレイタイムの計算
        SumDelayTime = aimTime + delayTime;

        // コンポーネントの取得
        _sr = GetComponent<SpriteRenderer>();

        // エイム中の色変え
        _sr.material = aimMaterial;

        // プレイヤーのオブジェクトを探索
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // タイマーを計測
        objTimer += Time.deltaTime;

        // 発射許可があるなら処理
        if (canLanch)
        {
            // エイム時間内の処理
            if (objTimer <= aimTime)
            {
                // プレイヤーのほうを向く
                transform.rotation = RotateTarget(player);
            }
            // エイム時間が終わったら
            else if (objTimer >= aimTime && canMaterialChange)
            {
                // 攻撃の色変え
                _sr.material = beamMaterial;

                // マテリアルの変更を停止
                canMaterialChange = false;
            }
            // ビームまでのディレイ時間を超えたら
            else if (objTimer >= SumDelayTime && canLanch)
            {
                objTimer = 0;

                // 発射
                Instantiate(beamPrefab, transform.position, transform.rotation);

                // 発射を停止
                canLanch = false;
            }
        }
        else
        {
            // 消滅時間を超えていたら消滅
            if (objTimer >= destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}