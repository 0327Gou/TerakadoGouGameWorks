/*
* �t�@�C���FMagicMeteor C#
* �V�X�e���F���e�I���@�𐶐��E�j������
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMeteor : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float chaseTime;        // �ǐՎ���

    [SerializeField]
    float delayTime;        // �f�B���C����

    [SerializeField]
    float destroyTime;      // ���Ŏ���

    [SerializeField]
    GameObject attackObj;   // �U���I�u�W�F�N�g

    [SerializeField]
    Material chaseMaterial;     // �ǐՎ��̃}�e���A��

    [SerializeField]
    Material meteorMaterial;    // ���e�I�U�����̃}�e���A��

    float objTimer;             // �I�u�W�F�N�g����������Ă���̎���
    float SumDelayTime;         // ��������Ă���U������܂ł̎���
    float SumDestroyTime;       // ��������Ă�����ł���܂ł̎���
    bool canMaterialChange;     // �}�e���A����ύX�\��
    bool canLanch;              // ���ˉ\��

    SpriteRenderer _sr;     // �X�v���C�g�����_���[�i�[�p
    GameObject player;      // �v���C���[�̃Q�[���I�u�W�F�N�g�i�[�p


    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    private void Start()
    {
        // ������
        objTimer = 0.0f;
        SumDelayTime = chaseTime + delayTime;
        SumDestroyTime = SumDelayTime + destroyTime;
        canLanch = true;
        canMaterialChange = true;

        // �R���|�[�l���g�̎擾
        _sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");

        // �`�F�C�X���̐F�ς�
        _sr.material = chaseMaterial;

        // ���W�����킹��
        transform.position = player.transform.position;
    }

    private void Update()
    {
        // �I�u�W�F�N�g����������Ă���̎��Ԃ��v������
        objTimer += Time.deltaTime;

        // �`�F�C�X���ԓ��̏���
        if (objTimer <= chaseTime)
        {
            // ���W�����킹�ăv���C���[��ǐՂ���
            transform.position = player.transform.position;
        }
        else if (objTimer > chaseTime && canMaterialChange)
        {
            // �U���̐F�ς�
            _sr.material = meteorMaterial;

            canMaterialChange = false;
        }
        // ���e�I�܂ł̃f�B���C���Ԃ𒴂�����
        else if (objTimer >= SumDelayTime && canLanch)
        {
            // ���g�̈ʒu�Ƀ��e�I�v���n�u���C���X�^���X
            Instantiate(attackObj, transform.position, Quaternion.identity);

            // ���˂��~
            canLanch = false;
        }
        else
        {
            // ���Ŏ��Ԃ𒴂��Ă����珈��
            if (objTimer >= SumDestroyTime)
            {
                // ����
                Destroy(gameObject);
            }
        }
    }
}