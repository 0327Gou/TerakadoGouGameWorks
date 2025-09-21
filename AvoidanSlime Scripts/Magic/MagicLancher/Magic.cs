/*
* �t�@�C���FMagic C#
* �V�X�e���F�P���U�����@�̐���
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MyFunctions
{
    [SerializeField]
    float delayTime;        // ���˂܂ł̗P�\����
    float delayTimer;       // ���˂܂ł̃^�C�}�[

    [SerializeField]
    float destroyTime;      // ���ł܂ł̎���
    float destroyTimer;     // ���ł܂ł̃^�C�}�[

    [SerializeField]
    GameObject obj;         // �e�̃v���n�u

    [SerializeField]
    AudioClip magicSound;   // ���@�����̉�

    bool CanLanch;          // ���ˋ���

    AudioSource _as;        // �I�[�f�B�I�\�[�X
    GameObject player;      // �v���C���[�i�[�p


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    private void Start()
    {
        // ������
        CanLanch = true;
        delayTimer = 0.0f;
        destroyTimer = 0.0f;

        // �R���|�[�l���g�̎擾
        _as = GetComponent<AudioSource>();

        // �v���C���[���擾
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (CanLanch)
        {
            // �v���C���[�̂ق�������
            transform.rotation = RotateTarget(player);

            // �f�B���C���v��
            delayTimer += Time.deltaTime;

            // �f�B���C���Ԃ𒴂��Ă����珈��
            if (delayTimer > delayTime)
            {
                // ���ˉ���炷
                _as.PlayOneShot(magicSound);

                // ����
                Instantiate(obj, transform.position, transform.rotation);

                // ���˂��~
                CanLanch = false;
            }
        }
        else
        {
            // ���Ŏ��Ԃ��v��
            destroyTimer += Time.deltaTime;
            
            // ���Ŏ��Ԃ𒴂��Ă��������
            if (destroyTimer > destroyTime)
            {
                Destroy(gameObject);
            }
        }
    }
}