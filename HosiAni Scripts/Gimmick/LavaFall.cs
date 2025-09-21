using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightChange : MonoBehaviour
{
    // �����n�߂鎞��
    [SerializeField]
    float m_fFallInterbal;

    float m_fMaxScale;          // �ő�X�P�[��
    float m_fNowScale;          // ���݂̃X�P�[��
    float m_fTimer;
    bool m_bDoExtend;           // �L�тĂ��邩�̃t���O
    Vector3 m_v3DefaultPos;     // �����ʒu���i�[����

    void Start()
    {
        // �t���O���~�낵�Ă���
        m_bDoExtend = false;
        // �ő�X�P�[�����i�[
        m_fMaxScale = transform.localScale.y;
        // �����ʒu���i�[
        m_v3DefaultPos = transform.position;
        // �l�̏�����
        m_fNowScale = 0.0f;
        m_fTimer = 0.0f;
        // �X�P�[����0�ɂ���
        transform.localScale = new Vector3(transform.localScale.x, m_fNowScale, transform.localScale.z);
    }

    void Update()
    {
        // �L�т����Ă�����
        if (!m_bDoExtend)
        {
            // ���Ԃ��v��
            m_fTimer += Time.deltaTime;

            // ���ɂ��炷�iPos�j
            transform.Translate(new Vector3(0f, -0.05f, 0f));
        }

        // ���Ԃ���������L�т鋖��
        if (m_fTimer > m_fFallInterbal)
        {
            // �t���O���グ��
            m_bDoExtend = true;
            // �^�C�}�[���Z�b�g
            m_fTimer = 0.0f;
            // ���W���ŏ��̍��W�ɖ߂�
            transform.position = m_v3DefaultPos;
            // �X�P�[����0�ɂ���
            m_fNowScale = 0.0f;
        }

        // �L�т�������p��
        if (m_fNowScale >= m_fMaxScale)
        {
            // �t���O���~�낷
            m_bDoExtend = false;
        }

        // �L�т鋖�������
        if (m_bDoExtend)
        {
            // �I�u�W�F�N�g��L�΂�
            m_fNowScale += 0.05f;
            transform.localScale = new Vector3(transform.localScale.x, m_fNowScale, transform.localScale.z);
        }
    }
}