using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloorMng : MonoBehaviour
{
    // 切り替わる時間
    [SerializeField]
    float m_fChangeTime;

    // A配列
    Transform[] m_obA;

    // B配列
    Transform[] m_obB;

    float m_fTimer;
    bool m_bChange;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        m_fTimer = 0.0f;

        // 子オブジェクトの数を取得
        int childCountA = transform.GetChild(0).transform.childCount;
        int childCountB = transform.GetChild(1).transform.childCount;

        // 子オブジェクト達を入れる配列の初期化
        m_obA = new Transform[childCountA];
        m_obB = new Transform[childCountB];

        // 孫オブジェクトを配列に入れる
        for (int i = 0; i < childCountA; ++i)
        {
            m_obA[i] = transform.GetChild(0).transform.GetChild(i);
            Debug.Log(m_obA[i].name);
        }

        for (int i = 0; i < childCountB; ++i)
        {
            m_obB[i] = transform.GetChild(1).transform.GetChild(i);
            Debug.Log(m_obB[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_fTimer += Time.deltaTime;

        if(m_fTimer >= m_fChangeTime)
        {
            // フラグを切り替える
            m_bChange = FlgChanger(m_bChange);

            if (m_bChange)
            {
                for (int i = 0; i < m_obA.Length; ++i)
                {
                    m_obA[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        0.25f);
                    m_obA[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
                for (int i = 0; i < m_obB.Length; ++i)
                {
                    m_obB[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        1f);
                    m_obB[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            else
            {
                for (int i = 0; i < m_obA.Length; ++i)
                {
                    m_obA[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obA[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        1.0f);
                    m_obA[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
                }
                for (int i = 0; i < m_obB.Length; ++i)
                {
                    m_obB[i].gameObject.GetComponent<SpriteRenderer>().color = new Color(
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.r,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.g,
                        m_obB[i].gameObject.GetComponent<SpriteRenderer>().color.b,
                        0.25f);
                    m_obB[i].gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }

            // 時間をリセットする
            m_fTimer = 0.0f;
        }
    
    }

    // フラグを反転させる関数
    bool FlgChanger(bool _flg)
    {
        // 反転させる
        if (_flg)
        {
            _flg = false;
        }
        else
        {
            _flg = true;
        }

        // 戻り値を返す
        return _flg;
    }
}
