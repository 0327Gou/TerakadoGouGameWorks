/*
* ファイル：Beam C#
* システム：ビームの処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float m_fTime_Amplification = 0.1f;       // ビーム増幅時間
    [SerializeField] float m_fTime_Duration = 3f;              // ビーム発射時間
    [SerializeField] float m_fTime_Attenuation = 0.05f;         // ビーム減衰時間

    float m_fTimer;                 // 時間計測用
    
    float m_fDefaultScaleX;         // 元のXのスケール
    float m_fScaleX;                // Xのスケール計算用

    float m_fAmplificationX;        // 毎秒の増幅値
    float m_fAttenuationX;          // 毎秒の減衰値

    GameObject BeamObj;     // ビームのオブジェクト
    BoxCollider2D _bc2;     // ボックスコライダー


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        // 初期化
        m_fTimer = 0f;
        m_fDefaultScaleX = transform.localScale.x;
        m_fScaleX = 0f;
        m_fAmplificationX = m_fDefaultScaleX / m_fTime_Amplification;
        m_fAttenuationX = m_fDefaultScaleX / m_fTime_Attenuation;

        BeamObj = transform.GetChild(0).gameObject;

        // コンポーネントの取得
        _bc2 = BeamObj.GetComponent<BoxCollider2D>();
        _bc2.enabled = false;
    }

    void Update()
    {
        // 時間の計測
        m_fTimer += Time.deltaTime;

        // 増幅
        if (m_fTimer <= m_fTime_Amplification)
        {
            // ビーム増幅
            m_fScaleX += m_fAmplificationX * Time.deltaTime;
            Vector3 v3Scale = new Vector2(m_fScaleX, transform.localScale.y);
            transform.localScale = v3Scale;
        }
        // 攻撃
        else if (m_fTimer <= m_fTime_Amplification + m_fTime_Duration)
        {
            if (!_bc2.enabled)
            {
                // 攻撃(collider起動)
                _bc2.enabled = true;
            }
        }

        // 減衰
        else if (m_fTimer <= m_fTime_Amplification + m_fTime_Duration + m_fTime_Attenuation)
        {
            // ビーム減衰
            Vector3 v3Scale = new Vector2(transform.localScale.x - (m_fAttenuationX * Time.deltaTime), transform.localScale.y);
            transform.localScale = v3Scale;
        }

        // 破棄（全ての実行時間が終わっていたら）
        else if (m_fTimer > m_fTime_Amplification + m_fTime_Duration + m_fTime_Attenuation)
        {
            Destroy(gameObject);
        }
    }
}