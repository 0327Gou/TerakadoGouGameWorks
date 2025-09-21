using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightChange : MonoBehaviour
{
    // 落ち始める時間
    [SerializeField]
    float m_fFallInterbal;

    float m_fMaxScale;          // 最大スケール
    float m_fNowScale;          // 現在のスケール
    float m_fTimer;
    bool m_bDoExtend;           // 伸びているかのフラグ
    Vector3 m_v3DefaultPos;     // 初期位置を格納する

    void Start()
    {
        // フラグを降ろしておく
        m_bDoExtend = false;
        // 最大スケールを格納
        m_fMaxScale = transform.localScale.y;
        // 初期位置を格納
        m_v3DefaultPos = transform.position;
        // 値の初期化
        m_fNowScale = 0.0f;
        m_fTimer = 0.0f;
        // スケールを0にする
        transform.localScale = new Vector3(transform.localScale.x, m_fNowScale, transform.localScale.z);
    }

    void Update()
    {
        // 伸びきっていたら
        if (!m_bDoExtend)
        {
            // 時間を計測
            m_fTimer += Time.deltaTime;

            // 下にずらす（Pos）
            transform.Translate(new Vector3(0f, -0.05f, 0f));
        }

        // 時間がたったら伸びる許可
        if (m_fTimer > m_fFallInterbal)
        {
            // フラグを上げる
            m_bDoExtend = true;
            // タイマーリセット
            m_fTimer = 0.0f;
            // 座標を最初の座標に戻す
            transform.position = m_v3DefaultPos;
            // スケールを0にする
            m_fNowScale = 0.0f;
        }

        // 伸びきったら却下
        if (m_fNowScale >= m_fMaxScale)
        {
            // フラグを降ろす
            m_bDoExtend = false;
        }

        // 伸びる許可があれば
        if (m_bDoExtend)
        {
            // オブジェクトを伸ばす
            m_fNowScale += 0.05f;
            transform.localScale = new Vector3(transform.localScale.x, m_fNowScale, transform.localScale.z);
        }
    }
}