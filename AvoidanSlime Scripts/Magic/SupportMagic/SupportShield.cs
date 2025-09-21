/*
* �t�@�C���FSupportShield C#
* �V�X�e���F�V�[���h�̔\�͂𐧌䂷�鏈��
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportShield : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    AudioClip reflectSound; // ���˂̉�

    AudioSource _as;        // �I�[�f�B�I�\�[�X


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    private void Start()
    {
        // �R���|�[�l���g�̎擾
        _as = GetComponent<AudioSource>();
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �^�O��Bullet�Ȃ珈��
        if(collision.gameObject.tag == "Bullet")
        {
            // �G�����I�u�W�F�N�g�̈ړ��ʂ��擾
            Rigidbody2D _rb = collision.GetComponent<Rigidbody2D>();
            Vector2 _velocity = _rb.velocity;

            // ���˂̌v�Z
            _velocity = Vector3.Reflect(_velocity, -transform.right);

            // �v�Z���ʂ𔽉f
            _rb.velocity = _velocity;

            // ���ʉ����o��
            _as.PlayOneShot(reflectSound);
        }
    }
}
