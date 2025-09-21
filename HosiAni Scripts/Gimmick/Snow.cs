using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Snow : MonoBehaviour
{
    // クールタイム（下の二つを足した値より大きくして）
    public float CoolTime = 0.0f;
    // 発動する時間
    public float ActiveTime = 0.0f;
    // 雪崩の予兆時間
    public float OmenTime = 0.0f;


    // 発動する時間を計測する変数
    private float ActiveTimer = 0.0f;
    // クールタイムを計測する変数
    private float CoolTimer = 0.0f;
    // 雪崩の予兆時間を計測する変数
    private float OmenTimer = 0.0f;

    bool omenflg = false;

    bool snowflg = false;

    // プレイヤー格納用
    GameObject Player;
    // 雪崩格納用
    public GameObject snow;
    // 雪崩の予兆格納用
    public GameObject omen;

    void Start()
    {
        // プレイヤーを探す
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        // クールタイムを計測
        CoolTimer += Time.deltaTime;

        // クールタイムが超えたら
        if(CoolTimer >= CoolTime)
        {   
            // プレイヤーの方向を向くようにする
            // 対象物へのベクトルを算出
            Vector2 toDirection = Player.transform.position - transform.position;
            // 対象物へ回転する
            transform.rotation = Quaternion.FromToRotation(Vector2.down, toDirection);

            // 雪崩を発動するフラグを立てる
            omenflg = true;

            // クールタイムをリセットする
            CoolTimer = 0.0f;
        }

        // クールタイムをが超えたら雪崩の予兆を発動
        if(omenflg)
        {
            // 予兆時間を計測
            OmenTimer += Time.deltaTime;

            // 雪崩の予兆を出す
            omen.SetActive(true);

            // 予兆時間が超えたら
            if (OmenTimer >= OmenTime)
            {
                snowflg = true;
                // 雪崩の予兆を非表示にする
                omen.SetActive(false);
            }
        }
        // 雪崩を発動
        if(snowflg)
        {
            // 発動時間を計測
            ActiveTimer += Time.deltaTime;

            // 雪崩を発動する
            snow.SetActive(true);

            // 発動時間が超えたら
            if (ActiveTimer >= ActiveTime)
            {
                // 雪崩を非表示にする
                snow.SetActive(false);

                // 発動時間をリセットする
                ActiveTimer = 0.0f;

                snowflg = false;
            }
            OmenTimer = 0.0f;
        }
    }
}
