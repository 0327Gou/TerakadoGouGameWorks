/*
* �t�@�C���FMagicShield C#
* �V�X�e���F�V�[���h���@�𐶐��A�j������X�N���v�g
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float destroyTime;          // ���Ŏ���
    float destroyTimer;         // ���Ŏ��Ԃ̃^�C�}�[

    [SerializeField]
    GameObject shieldPrefab;    // �V�[���h�̃v���n�u

    [SerializeField]
    string targetTag;           // �^�[�Q�b�g�̃^�O

    bool canLanch;              // ���ˉ\���̃t���O

    GameObject targetObj;       // �^�[�Q�b�g�I�u�W�F�N�g


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    private void Start()
    {
        // ������
        destroyTimer = 0.0f;
        canLanch = true;

        // �^�O����Q�[���I�u�W�F�N�g���擾
        targetObj = GameObject.FindWithTag(targetTag);
    }

    // ���t���[���̏���
    private void Update()
    {
        // �^�[�Q�b�g�̈ʒu�ֈړ�
        transform.position = targetObj.transform.position;

        // ���ˉ\�Ȃ珈��
        if (canLanch)
        {
            // ���g�̈ʒu�ɃV�[���h�v���n�u���q�I�u�W�F�N�g�Ƃ��Đ���
            GameObject childObject = Instantiate(shieldPrefab, transform.position, Quaternion.identity);

            // ���˂��~
            canLanch = false;
        }
        else
        {
            // ���Ԃ�����������鏈��
            // ���Ԃ��v��
            destroyTimer += Time.deltaTime;

            // ���Ŏ��Ԃ𒴂��Ă����珈��
            if (destroyTimer > destroyTime)
            {
                // �I�u�W�F�N�g������
                Destroy(gameObject);
            }
        }
    }
}