/*
* �t�@�C���FSupportEnhance C#
* �V�X�e���F�������@�̏���
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportEnhance : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    float m_destroyTime;        // ���Ŏ���
    float m_destroyTimer;       // ���Ŏ��Ԃ̃^�C�}�[

    [SerializeField]
    AudioClip enhanceSound;     // �G���n���X�̃_���[�W�A�b�v��
    
    AudioSource _as;            // �I�[�f�B�I�\�[�X


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    void Start()
    {
        // ������
        m_destroyTimer = 0.0f;

        // �R���|�[�l���g�̎擾
        _as = GetComponent<AudioSource>();
    }

    // ���t���[���̏���
    void Update()
    {
        // ���Ŏ��Ԃ��v��
        m_destroyTimer += Time.deltaTime;

        // ���Ԃ𒴂�����
        if (m_destroyTimer > m_destroyTime)
        {
            // �I�u�W�F�N�g������
            Destroy(gameObject);
        }
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �^�O��Bullet��EnemyBullet�Ȃ珈��
        if(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            // �U���͂�������
            collision.GetComponent<Attack>().Enhance();

            // ���ʃA�b�v�̌��ʉ���炷
            _as.PlayOneShot(enhanceSound);
        }
    }
}
