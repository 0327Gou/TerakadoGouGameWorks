/*
* �t�@�C���FShieldMng C#
* �V�X�e���F�V�[���h�̐����Ǘ����鏈��
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMng : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float m_destroyTime;        // ���ł܂ł̎���
    float m_destroyTimer;       // ���Ŏ��Ԃ��v������^�C�}�[

    Transform[] children;       // �q�I�u�W�F�N�g�i�[�p


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    private void Start()
    {
        // ������
        m_destroyTimer = 0;

        // �q�I�u�W�F�N�g���擾
        children = GetChildren(gameObject.transform);
    }

    // ���t���[���̏���
    private void Update()
    {
        // ���Ŏ��Ԃ̌v��
        m_destroyTimer += Time.deltaTime;

        // ���Ŏ��Ԃ𒴂��Ă����珈��
        if (m_destroyTimer >= m_destroyTime)
        {
            // �^�C�}�[�����Z�b�g
            m_destroyTimer = 0;

            // �q�I�u�W�F�N�g���������č폜
            for (int i = 0; i < children.Length; ++i)
            {
                Destroy(children[i].gameObject);
            }
            // ���g���폜
            Destroy(gameObject);
        }
    }
}
