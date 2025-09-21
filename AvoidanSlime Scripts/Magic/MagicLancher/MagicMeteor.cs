/*
* ファイル：MagicMeteor C#
* システム：メテオ魔法を生成・破棄する
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMeteor : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float chaseTime;        // 追跡時間

    [SerializeField]
    float delayTime;        // ディレイ時間

    [SerializeField]
    float destroyTime;      // 消滅時間

    [SerializeField]
    GameObject attackObj;   // 攻撃オブジェクト

    [SerializeField]
    Material chaseMaterial;     // 追跡時のマテリアル

    [SerializeField]
    Material meteorMaterial;    // メテオ攻撃時のマテリアル

    float objTimer;             // オブジェクトが生成されてからの時間
    float SumDelayTime;         // 生成されてから攻撃するまでの時間
    float SumDestroyTime;       // 生成されてから消滅するまでの時間
    bool canMaterialChange;     // マテリアルを変更可能か
    bool canLanch;              // 発射可能か

    SpriteRenderer _sr;     // スプライトレンダラー格納用
    GameObject player;      // プレイヤーのゲームオブジェクト格納用


    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    private void Start()
    {
        // 初期化
        objTimer = 0.0f;
        SumDelayTime = chaseTime + delayTime;
        SumDestroyTime = SumDelayTime + destroyTime;
        canLanch = true;
        canMaterialChange = true;

        // コンポーネントの取得
        _sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");

        // チェイス中の色変え
        _sr.material = chaseMaterial;

        // 座標を合わせる
        transform.position = player.transform.position;
    }

    private void Update()
    {
        // オブジェクトが生成されてからの時間を計測する
        objTimer += Time.deltaTime;

        // チェイス時間内の処理
        if (objTimer <= chaseTime)
        {
            // 座標を合わせてプレイヤーを追跡する
            transform.position = player.transform.position;
        }
        else if (objTimer > chaseTime && canMaterialChange)
        {
            // 攻撃の色変え
            _sr.material = meteorMaterial;

            canMaterialChange = false;
        }
        // メテオまでのディレイ時間を超えたら
        else if (objTimer >= SumDelayTime && canLanch)
        {
            // 自身の位置にメテオプレハブをインスタンス
            Instantiate(attackObj, transform.position, Quaternion.identity);

            // 発射を停止
            canLanch = false;
        }
        else
        {
            // 消滅時間を超えていたら処理
            if (objTimer >= SumDestroyTime)
            {
                // 消滅
                Destroy(gameObject);
            }
        }
    }
}