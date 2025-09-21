using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour
{
    // êLÇ—ÇÈë¨Ç≥
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
        // èkÇ›êÿÇ¡ÇƒÇ¢ÇΩÇÁ
        if (m_fNowScale <= 0.0f)
        {
            m_fNowScale = 0.0f;
            m_bDoExtend = true;
        }

        // êLÇ—Ç´Ç¡ÇƒÇ¢ÇΩÇÁ
        if (m_fNowScale >= m_fMaxScale)
        {
            m_fNowScale = m_fMaxScale;
            m_bDoExtend = false;
        }

        // êLÇ—ÇÈãñâ¬Ç™Ç†ÇÈ
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