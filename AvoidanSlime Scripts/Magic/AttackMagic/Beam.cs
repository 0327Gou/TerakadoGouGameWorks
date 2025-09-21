/*
* �t�@�C���FBeam C#
* �V�X�e���F�r�[���̏���
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float m_fTime_Amplification = 0.1f;       // �r�[����������
    [SerializeField] float m_fTime_Duration = 3f;              // �r�[�����ˎ���
    [SerializeField] float m_fTime_Attenuation = 0.05f;         // �r�[����������

    float m_fTimer;                 // ���Ԍv���p
    
    float m_fDefaultScaleX;         // ����X�̃X�P�[��
    float m_fScaleX;                // X�̃X�P�[���v�Z�p

    float m_fAmplificationX;        // ���b�̑����l
    float m_fAttenuationX;          // ���b�̌����l

    GameObject BeamObj;     // �r�[���̃I�u�W�F�N�g
    BoxCollider2D _bc2;     // �{�b�N�X�R���C�_�[


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        // ������
        m_fTimer = 0f;
        m_fDefaultScaleX = transform.localScale.x;
        m_fScaleX = 0f;
        m_fAmplificationX = m_fDefaultScaleX / m_fTime_Amplification;
        m_fAttenuationX = m_fDefaultScaleX / m_fTime_Attenuation;

        BeamObj = transform.GetChild(0).gameObject;

        // �R���|�[�l���g�̎擾
        _bc2 = BeamObj.GetComponent<BoxCollider2D>();
        _bc2.enabled = false;
    }

    void Update()
    {
        // ���Ԃ̌v��
        m_fTimer += Time.deltaTime;

        // ����
        if (m_fTimer <= m_fTime_Amplification)
        {
            // �r�[������
            m_fScaleX += m_fAmplificationX * Time.deltaTime;
            Vector3 v3Scale = new Vector2(m_fScaleX, transform.localScale.y);
            transform.localScale = v3Scale;
        }
        // �U��
        else if (m_fTimer <= m_fTime_Amplification + m_fTime_Duration)
        {
            if (!_bc2.enabled)
            {
                // �U��(collider�N��)
                _bc2.enabled = true;
            }
        }

        // ����
        else if (m_fTimer <= m_fTime_Amplification + m_fTime_Duration + m_fTime_Attenuation)
        {
            // �r�[������
            Vector3 v3Scale = new Vector2(transform.localScale.x - (m_fAttenuationX * Time.deltaTime), transform.localScale.y);
            transform.localScale = v3Scale;
        }

        // �j���i�S�Ă̎��s���Ԃ��I����Ă�����j
        else if (m_fTimer > m_fTime_Amplification + m_fTime_Duration + m_fTime_Attenuation)
        {
            Destroy(gameObject);
        }
    }
}