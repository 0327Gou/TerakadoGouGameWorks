/*
* �t�@�C���FMagicBeam C#
* �V�X�e���F�r�[�����@�̐���
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBeam : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float aimTime;          // �G�C������

    [SerializeField]
    float delayTime;        // �f�B���C����
    float SumDelayTime;     // �f�B���C���Ԃ̃^�C�}�[

    [SerializeField]
    float destroyTime;      // ���ł܂ł̎���

    [SerializeField]
    GameObject beamPrefab;  // �r�[���v���n�u

    // �}�e���A��
    [SerializeField]
    Material aimMaterial;   // �G�C�����̃}�e���A��

    [SerializeField]
    Material beamMaterial;  // �r�[�����̃}�e���A��

    bool canLanch;          // ���ˋ���
    bool canMaterialChange; // �}�e���A���̕ύX����
    float objTimer;         // �I�u�W�F�N�g�̐�������̎���

    SpriteRenderer _sr;     // �X�v���C�g�����_���[�i�[�p
    GameObject player;      // �v���C���[�̃Q�[���I�u�W�F�N�g�i�[�p


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    private void Start()
    {
        // ������
        canLanch = true;
        canMaterialChange = true;
        objTimer = 0.0f;

        // �f�B���C�^�C���̌v�Z
        SumDelayTime = aimTime + delayTime;

        // �R���|�[�l���g�̎擾
        _sr = GetComponent<SpriteRenderer>();

        // �G�C�����̐F�ς�
        _sr.material = aimMaterial;

        // �v���C���[�̃I�u�W�F�N�g��T��
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // �^�C�}�[���v��
        objTimer += Time.deltaTime;

        // ���ˋ�������Ȃ珈��
        if (canLanch)
        {
            // �G�C�����ԓ��̏���
            if (objTimer <= aimTime)
            {
                // �v���C���[�̂ق�������
                transform.rotation = RotateTarget(player);
            }
            // �G�C�����Ԃ��I�������
            else if (objTimer >= aimTime && canMaterialChange)
            {
                // �U���̐F�ς�
                _sr.material = beamMaterial;

                // �}�e���A���̕ύX���~
                canMaterialChange = false;
            }
            // �r�[���܂ł̃f�B���C���Ԃ𒴂�����
            else if (objTimer >= SumDelayTime && canLanch)
            {
                objTimer = 0;

                // ����
                Instantiate(beamPrefab, transform.position, transform.rotation);

                // ���˂��~
                canLanch = false;
            }
        }
        else
        {
            // ���Ŏ��Ԃ𒴂��Ă��������
            if (objTimer >= destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}