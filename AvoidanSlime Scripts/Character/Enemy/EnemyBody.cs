/*
 * �t�@�C���FEnemyBody C#
 * �V�X�e���F�G�̑̂̏����B�v���C���[���G���ƃ_���[�W���󂯂�
 * 
 * Created by ���� ��H
 * 2025�N �ꕔ�ύX
 */

using UnityEngine;

public class EnemyBody : MyFunctions
{
    //-------------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //-------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] int damage;                    // �_���[�W    
    [SerializeField] float damageDelayTime;         // �_���[�W�̃f�B���C����
    float damageDelayTimer;                         // �_���[�W�̃f�B���C���Ԃ̃^�C�}�[

    //-------------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //-------------------------------------------------------------------------------------------------------------------------------

    // �������Ă���Ԃ̏���
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �v���C���[������
        if (collision.gameObject.tag == "Player")
        {
            // �_���[�W�̃f�B���C���v��
            damageDelayTimer += Time.deltaTime;

            // �f�B���C�^�C���𒴂��Ă�����
            if (damageDelayTimer >= damageDelayTime)
            {
                // HP���擾���ăv���C���[�Ƀ_���[�W��^����
                PlayerHP _HP = collision.GetComponent<PlayerHP>();
                _HP.AddDamage(damage);

                // �^�C�}�[�����Z�b�g
                damageDelayTimer = 0;
            }
        }
    }
}
