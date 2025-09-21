/*
 * �t�@�C���FEnemyMove C#
 * �V�X�e���F�G�̈ړ�����
 * Created by ���� ��H
 * 2025�N �ꕔ�ύX
 */

using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //-------------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float moveSpeed;       // �G�̈ړ��X�s�[�h    
    [SerializeField] float moveTime;        // �����ňړ�����܂ł̎���
    [SerializeField] Vector2[] position;    // �ړ��ӏ��̔z��
    int moveCount;      // �ړ��J�E���g
    float moveTimer;    // �ړ�

    [SerializeField] GameObject magic;   // �ړ����̍U���v���n�u

    //-------------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //-------------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    void Start()
    {
        // ������
        moveTimer = 0;
    }

    // ���t���[���̏���
    void Update()
    {
        // ���Ԃ��v��
        moveTimer += Time.deltaTime;

        // ���Ԍo�߂Ŏ��̏ꏊ�Ɉړ�����
        if (moveTimer >= moveTime)
        {
            moveTimer = 0.0f;   // �^�C�}�[�̏�����
            moveCount++;        // �J�E���g�̑���

            // �ړ��J�E���g���z��̐��ȏ�ɂȂ�����
            if (moveCount >= position.Length)
            {
                moveCount = 0;      // �J�E���g��0�ɖ߂��B�����I�ɍŏ��̃|�W�V������ڎw���B
            }

            // �ړ��O�Ɏ����̈ʒu����U������
            Instantiate(magic, transform.position, transform.rotation);
        }

        // �ڕW�n�_�܂ňړ�����
        transform.position = Vector3.MoveTowards(transform.position, position[moveCount], moveSpeed * Time.deltaTime);
    }
}
