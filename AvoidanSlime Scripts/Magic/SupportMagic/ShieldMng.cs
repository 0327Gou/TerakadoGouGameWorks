/*
* ファイル：ShieldMng C#
* システム：シールドの数を管理する処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMng : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float m_destroyTime;        // 消滅までの時間
    float m_destroyTimer;       // 消滅時間を計測するタイマー

    Transform[] children;       // 子オブジェクト格納用


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    private void Start()
    {
        // 初期化
        m_destroyTimer = 0;

        // 子オブジェクトを取得
        children = GetChildren(gameObject.transform);
    }

    // 毎フレームの処理
    private void Update()
    {
        // 消滅時間の計測
        m_destroyTimer += Time.deltaTime;

        // 消滅時間を超えていたら処理
        if (m_destroyTimer >= m_destroyTime)
        {
            // タイマーをリセット
            m_destroyTimer = 0;

            // 子オブジェクトを検索して削除
            for (int i = 0; i < children.Length; ++i)
            {
                Destroy(children[i].gameObject);
            }
            // 自身を削除
            Destroy(gameObject);
        }
    }
}
