/*
* �t�@�C���FSatelliteOrbit C#
* �V�X�e���F�^�[�Q�b�g�𒆐S�Ƃ��ĉq���̂悤�Ɏ���O��������X�N���v�g
*           ���񂷂鎞�̓^�[�Q�b�g���E���Ƃ��ď������i�s�����Ɍ�����
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteOrbit : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] 
    float m_fRadius;    // ���a�i�f���Ƃ̋����j

    [SerializeField]
    float m_fSpeed;     // ���x�i���񑬓x�j

    [SerializeField, Range(0.0f, 360.0f)] 
    float m_fPhi;       // �p�x�i�����ʒu�A�����ʑ��j

    [SerializeField]
    string targetTag;   // �^�[�Q�b�g�̃^�O�i�f���A��]�̒��S�A��]���j

    float m_fPhiPI;     // �ʑ�

    GameObject m_obAxis;    // �^�[�Q�b�g�̃Q�[���I�u�W�F�N�g


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    void Start()
    {
        // �^�[�Q�b�g���^�O�Ŏ擾
        m_obAxis = GameObject.FindWithTag(targetTag);

        // �ʑ��̌v�Z�Ɣ��f
        m_fPhiPI = (m_fPhi * Mathf.PI) / 180;
    }

    // ���t���[���̏���
    void Update()
    {
        // X����Y���̐ݒ�
        float m_fX = m_fRadius * Mathf.Sin(Time.time * m_fSpeed + m_fPhiPI);
        float m_fY = m_fRadius * Mathf.Cos(Time.time * m_fSpeed + m_fPhiPI);

        // ���W�𓮂���
        transform.position = new Vector3(m_fX + m_obAxis.transform.position.x, m_fY + m_obAxis.transform.position.y);

        // �^�[�Q�b�g�̕������擾
        Vector2 lookDir = transform.position - m_obAxis.transform.position;

        // �^�[�Q�b�g�̈ʒu���E�Ɍ����B�i�s�����������悤�ɂȂ�
        transform.rotation = Quaternion.FromToRotation(Vector3.right, lookDir);
    }
}
