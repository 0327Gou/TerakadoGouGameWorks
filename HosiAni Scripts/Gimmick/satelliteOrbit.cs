using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class satelliteOrbit : MonoBehaviour
{
    // [SerializeField]
    // ˜f¯i‰ñ“]‚Ì’†SA‰ñ“]²j
    [SerializeField]
    GameObject m_obAxis;

    // ü‰ñ‘¬“x
    [SerializeField]
    float m_fSpeed;

    // ¶‰ñ“]
    [SerializeField]
    bool m_bLeftRot;

    // private
    // ˜f¯‚Æ‚Ì‹——£i”¼Œaj
    float m_fRadius;

    // Šp“xi‰ŠúˆÊ’uA‰ŠúˆÊ‘Šj
    float m_fPhi;

    Vector3 m_v3Pos;
    float m_fSin;
    float m_fCos;

    // Start is called before the first frame update
    void Start()
    {
        // ˜f¯‚ÌˆÊ’u‚ğ•Û‘¶
        m_v3Pos = m_obAxis.transform.position;

        // ˜f¯‚Æ‚Ì‹——£‚ğ•Û‘¶
        m_fRadius = Vector3.Distance(m_v3Pos, transform.position);

        // ˜f¯‚©‚ç‚Ì‘Š‘ÎŠp“x‚ğ•Û‘¶(*-1‚Å”½“]C³)
        m_fPhi = (GetAngle(m_obAxis.transform.position, transform.position) - 90f) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        // ‰ñ“]ˆ—
        m_fSin = m_fRadius * Mathf.Sin(Time.time * m_fSpeed + m_fPhi);      // X²‚Ìİ’è
        m_fCos = m_fRadius * Mathf.Cos(Time.time * m_fSpeed + m_fPhi);      // Y²‚Ìİ’è

        // À•W‚ğXVˆ—
        if (m_bLeftRot)
        {
            transform.position = new Vector3(m_fCos + m_v3Pos.x, m_fSin + m_v3Pos.y, m_v3Pos.z);
        }
        else
        {
            transform.position = new Vector3(m_fSin + m_v3Pos.x, m_fCos + m_v3Pos.y, m_v3Pos.z);
        }
        transform.up = m_obAxis.transform.position - transform.position;
    }

    // 2“_Šp“x‚ğ‹‚ß‚é
    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        return rad;
    }
}
