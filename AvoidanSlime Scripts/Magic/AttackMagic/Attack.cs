/*
* �t�@�C���FAttack C#
* �V�X�e���F�U���̃x�[�X�ƂȂ鏈��
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;

public class Attack : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------
        
    [SerializeField]
    int damage;     // �_���[�W
    
    [SerializeField]
    protected bool canEnemyDamage;  // �G�Ƀ_���[�W��^���邩�H


    //----------------------------------------------------------------------------------------------------------------------------
    // �T�u�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�U���͂�2�{�ɂ���֐�
    /// ����    �F�Ȃ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void Enhance()
    {
        // ���@�w
        damage *= 2;
        //Debug.Log("2�{�ɂȂ���");
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // �^�O���v���C���[�Ȃ珈������
        if (collision.gameObject.tag == "Player")
        {
            // �v���C���[��HP���擾���ă_���[�W��^����
            PlayerHP _HP = collision.GetComponent<PlayerHP>();
            _HP.AddDamage(damage);
        }

        // �����Ȃ��Ȃ�I��
        if (!canEnemyDamage) { return; }

        // �^�O���G�l�~�[�Ȃ珈������
        if (collision.gameObject.tag == "Enemy")
        {
            // �G��HP���擾���ă_���[�W��^����
            EnemyHP _HP = collision.GetComponent<EnemyHP>();
            _HP.AddDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �ǂɐG�ꂽ�����
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
