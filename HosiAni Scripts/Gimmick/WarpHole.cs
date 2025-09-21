using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpHole : MonoBehaviour
{
    // ���[�v�̃C���^�[�o��
    [SerializeField]
    float m_fInterbal = 3.0f;

    // ���[�v��̃I�u�W�F�N�g
    [SerializeField]
    GameObject m_obWarpHole;

    //// private

    // �R���C�_�[�ۑ��p
    CapsuleCollider2D m_cc2D;

    // Script�ۑ��p
    WarpHole m_wh;

    // ���Ԍv��
    float m_fTimer;

    private void Start()
    {
        // ������
        m_cc2D = GetComponent<CapsuleCollider2D>();
        m_wh = m_obWarpHole.GetComponent<WarpHole>();
    }

    private void Update()
    {
        // �R���C�_�[���I�t�̎��������Ԃ��v��
        if (!m_cc2D.enabled)
        {
            m_fTimer += Time.deltaTime;
        }

        // �C���^�[�o���𒴂�����R���C�_�[���I���ɂ���
        if (m_fTimer >= m_fInterbal)
        {
            OnCollider();
        }
    }

    // �R���C�_�[�̃I���I�t�̐؂�ւ�
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
        // �v���C���[�ɐG��Ă����珈������
        if (collision.gameObject.tag == "Player")
        {
            // ���[�v���I�t
            OffCollider();
            m_wh.OffCollider();

            // �C���^�[�o��
            m_fTimer = 0.0f;
            m_wh.m_fTimer = 0.0f;

            // �v���C���[�����[�v������
            collision.transform.position = m_obWarpHole.transform.position;
        }
    }
}
