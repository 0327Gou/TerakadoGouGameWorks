using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpHole : MonoBehaviour
{
    // ワープのインターバル
    [SerializeField]
    float m_fInterbal = 3.0f;

    // ワープ先のオブジェクト
    [SerializeField]
    GameObject m_obWarpHole;

    //// private

    // コライダー保存用
    CapsuleCollider2D m_cc2D;

    // Script保存用
    WarpHole m_wh;

    // 時間計測
    float m_fTimer;

    private void Start()
    {
        // 初期化
        m_cc2D = GetComponent<CapsuleCollider2D>();
        m_wh = m_obWarpHole.GetComponent<WarpHole>();
    }

    private void Update()
    {
        // コライダーがオフの時だけ時間を計測
        if (!m_cc2D.enabled)
        {
            m_fTimer += Time.deltaTime;
        }

        // インターバルを超えたらコライダーをオンにする
        if (m_fTimer >= m_fInterbal)
        {
            OnCollider();
        }
    }

    // コライダーのオンオフの切り替え
    public void OffCollider()
    {
        if (m_cc2D.enabled)
        {
            m_cc2D.enabled = false;
        }
    }

    public void OnCollider()
    {
        if (!m_cc2D.enabled)
        {
            m_cc2D.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーに触れていたら処理する
        if (collision.gameObject.tag == "Player")
        {
            // ワープをオフ
            OffCollider();
            m_wh.OffCollider();

            // インターバル
            m_fTimer = 0.0f;
            m_wh.m_fTimer = 0.0f;

            // プレイヤーをワープさせる
            collision.transform.position = m_obWarpHole.transform.position;
        }
    }
}
