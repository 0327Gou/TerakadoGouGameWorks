/*
* ファイル：SupportShield C#
* システム：シールドの能力を制御する処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportShield : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    AudioClip reflectSound; // 反射の音

    AudioSource _as;        // オーディオソース


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    private void Start()
    {
        // コンポーネントの取得
        _as = GetComponent<AudioSource>();
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //----------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // タグがBulletなら処理
        if(collision.gameObject.tag == "Bullet")
        {
            // 触ったオブジェクトの移動量を取得
            Rigidbody2D _rb = collision.GetComponent<Rigidbody2D>();
            Vector2 _velocity = _rb.velocity;

            // 反射の計算
            _velocity = Vector3.Reflect(_velocity, -transform.right);

            // 計算結果を反映
            _rb.velocity = _velocity;

            // 効果音を出す
            _as.PlayOneShot(reflectSound);
        }
    }
}
