using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour
{
    // �L�т鑬��
    [SerializeField]
    float m_fExtendSpeed;

    float m_fMaxScale;
    float m_fNowScale;
    bool m_bDoExtend;

    void Start()
    {
        m_bDoExtend = true;
        m_fMaxScale = transform.localScale.y;
        m_fNowScale = 0.0f;
        transform.localScale = new Vector3(transform.localScale.x, m_fNowScale, transform.localScale.z);
    }

    void Update()
    {
        // �k�ݐ؂��Ă�����
        if (m_fNowScale <= 0.0f)
        {
            m_fNowScale = 0.0f;
            m_bDoExtend = true;
        }

        // �L�т����Ă�����
        if (m_fNowScale >= m_fMaxScale)
        {
            m_fNowScale = m_fMaxScale;
            m_bDoExtend = false;
        }

        // �L�т鋖������
        if (m_bDoExtend)
        {
            m_fNowScale += m_fExtendSpeed;
            transform.localScale = new Vector3(transform.localScale.x, m_fNowScale, transform.localScale.z);
        }
        else
        {
            m_fNowScale -= m_fExtendSpeed;
            transform.localScale = new Vector3(transform.localScale.x, m_fNowScale, transform.localScale.z);
        }
    }
}