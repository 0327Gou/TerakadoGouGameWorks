/*
* �t�@�C���FAttackBeam C#
* �V�X�e���F�r�[���̍U������
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBeam : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------
        
    [SerializeField]
    int dps;    // �b�ԃ_���[�W

    // �~�σ_���[�W
    float playerDamage;
    float enemyDamage;

    // �_���[�W��^�����邩�ǂ���
    bool canDamagePlayer;
    bool canDamageEnemy;

    PlayerHP _playerHP;     // �v���C���[��HP
    EnemyHP _enemyHP;       // �G��HP


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    private void Start()
    {
        // ������ 
        playerDamage = 0.0f;
        enemyDamage = 0.0f;

        canDamageEnemy = false;
        canDamagePlayer = false;

        _enemyHP = null;
        _playerHP = null;
    }

    // ���t���[���̏���
    private void Update()
    {
        // �G�Ƀ_���[�W��^������Ȃ珈������
        if (canDamageEnemy)
        {
            // DPS�����Z
            enemyDamage += dps * Time.deltaTime;

            // �~�ς��ꂽ�_���[�W��1�𒴂����珈��
            if (enemyDamage >= 1.0f)
            {
                // �_���[�W�������
                --enemyDamage;

                // �_���[�W��^����                
                _enemyHP.AddDamage(1);
            }
        }

        // �v���C���[�Ƀ_���[�W��^������Ȃ珈������
        if (canDamagePlayer)
        {
            // DPS�����Z
            playerDamage += dps * Time.deltaTime;

            // �~�ς��ꂽ�_���[�W��1�𒴂����珈��
            if (playerDamage >= 1.0f)
            {
                // �_���[�W�������
                --playerDamage;

                // �_���[�W��^����
                _playerHP.AddDamage(1);
            }
        }
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �^�O���G�Ȃ珈������
        if (collision.gameObject.tag == "Enemy")
        {
            // �G��HP���擾
            _enemyHP = collision.GetComponent<EnemyHP>();
            
            // �擾�ł��Ă�Ώ���
            if (_enemyHP != null)
            {
                // �_���[�W������
                canDamageEnemy = true;
            }
            else
            {
                // �G���Ȃ��Əo��
                Debug.LogError("AttackBeam : Enemy null");
            }
        }

        // �v���C���[�ւ̃_���[�W
        if (collision.gameObject.tag == "Player")
        {
            // �v���C���[��HP���擾
            _playerHP = collision.GetComponent<PlayerHP>();

            // �擾�ł��Ă���Ώ���
            if (_playerHP != null)
            {
                // �v���C���[�ւ̃_���[�W������
                canDamagePlayer = true;
            }
            else
            {
                Debug.LogError("AttackBeam�FPlayer null");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �G�̃^�O�𔻒�
        if (collision.gameObject.tag == "Enemy")
        {
            // �_���[�W���p������
            canDamagePlayer = false;
        }

        // �v���C���[�̃^�O�𔻒�
        if (collision.gameObject.tag == "Player")
        {
            // �_���[�W���p��
            canDamagePlayer = false;
        }
    }

}
