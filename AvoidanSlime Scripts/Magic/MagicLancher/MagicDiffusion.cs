/*
* �t�@�C���FMagicDiffusion C#
* �V�X�e���F�g�U�U�����@�̐�������
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDiffusion : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float DelayTime;        // �f�B���C����
    float DelayTimer;       // �f�B���C���Ԃ̃^�C�}�[

    [SerializeField]
    float DestroyTime;      // ���Ŏ���
    float DestroyTimer;     // ���Ŏ��Ԃ̃^�C�}�[

    [SerializeField]
    float spreadAngle;      // �g�U�p�x

    [SerializeField]
    int nWay;               // �Ȃ�����ɏo����

    [SerializeField]
    bool toPlayer;          // �v���C���[�֌�����

    [SerializeField]
    AudioClip magicSound;       // ���@�����̉� 

    [SerializeField]
    GameObject bulletPrefab;    // �e�̃v���n�u

    bool CanLanch;              // ���ˉ\��

    AudioSource _as;        // �I�[�f�B�I�\�[�X
    GameObject player;      // �v���C���[�̃I�u�W�F�N�g


    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    private void Start()
    {
        // ������
        CanLanch = true;
        DelayTimer = 0.0f;
        DestroyTimer = 0.0f;

        // �R���|�[�l���g�̎擾
        _as = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // ���ˉ\�Ȃ珈��
        if (CanLanch)
        {
            // �v���C���[�ɂ����Ă����Ȃ珈��
            if (toPlayer)
            {
                // �v���C���[�̂ق�������
                transform.rotation = RotateTarget(player);
            }

            // �f�B���C���Ԃ̌v��
            DelayTimer += Time.deltaTime;

             // �f�B���C�^�C���𒴂����珈��
            if (DelayTimer > DelayTime)
            {
                // �e����̊p�x
                float oneSpreadAngle = spreadAngle / (nWay - 1);

                // ���ˉ���炷
                _as.PlayOneShot(magicSound);

                // �ݒ肵��������
                for (int i = 0; i < nWay; ++i)
                {
                    // �p�x�����炷
                    float Angle = (oneSpreadAngle * i) - (spreadAngle / 2);

                    Quaternion rot = transform.rotation * Quaternion.Euler(0,0, Angle);

                    // �I�u�W�F�N�g�𐶐�
                    Instantiate(bulletPrefab, transform.position, rot);
                }

                // ���Z�b�g
                CanLanch = false;
                DelayTimer = 0;
            }
        }
        else
        {
            // ���ł܂ł̎��Ԃ̌v��
            DestroyTimer += Time.deltaTime;

            // ���Ŏ��Ԉȏ�Ȃ珈��
            if (DestroyTimer > DestroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
