using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class satelliteOrbit : MonoBehaviour
{
    // [SerializeField]
    // �f���i��]�̒��S�A��]���j
    [SerializeField]
    GameObject m_obAxis;

    // ���񑬓x
    [SerializeField]
    float m_fSpeed;

    // ����]
    [SerializeField]
    bool m_bLeftRot;

    // private
    // �f���Ƃ̋����i���a�j
    float m_fRadius;

    // �p�x�i�����ʒu�A�����ʑ��j
    float m_fPhi;

    Vector3 m_v3Pos;
    float m_fSin;
    float m_fCos;

    // Start is called before the first frame update
    void Start()
    {
        // �f���̈ʒu��ۑ�
        m_v3Pos = m_obAxis.transform.position;

        // �f���Ƃ̋�����ۑ�
        m_fRadius = Vector3.Distance(m_v3Pos, transform.position);

        // �f������̑��Ίp�x��ۑ�(*-1�Ŕ��]�C��)
        m_fPhi = (GetAngle(m_obAxis.transform.position, transform.position) - 90f) * -1;
    }

    // Update is called once per frame
    void Update()
    {
        // ��]����
        m_fSin = m_fRadius * Mathf.Sin(Time.time * m_fSpeed + m_fPhi);      // X���̐ݒ�
        m_fCos = m_fRadius * Mathf.Cos(Time.time * m_fSpeed + m_fPhi);      // Y���̐ݒ�

        // ���W���X�V����
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

    // 2�_�p�x�����߂�
    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        return rad;
    }
}
