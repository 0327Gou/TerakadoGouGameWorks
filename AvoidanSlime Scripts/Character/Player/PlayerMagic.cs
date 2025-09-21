/*
* �t�@�C���FPlayerMagic C#
* �V�X�e���F�v���C���[�̖��@����
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagic : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float magicCoolTime;             // ���@�̃N�[���^�C��
    [SerializeField] GameObject magicPrefab = null;   // ���@�̃v���n�u

    bool canMagic;            // ���@���g���邩�̃t���O
    float magicCoolTimer;     // ���@�̃N�[���^�C�}�[

    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    void Start()
    {
        // ������
        canMagic = true;
        magicCoolTimer = 0.0f;
    }

    // ���t���[���̏���
    void Update()
    {
        // �N�[���^�C�����v��
        magicCoolTimer += Time.deltaTime;
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // �C�x���g�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F���@�̓��͂����m���Ĕ�������
    /// ����    �FIA context
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void IA_Magic(InputAction.CallbackContext context)
    {
        // Performed�t�F�[�Y�̔�����s��
        if (context.phase == InputActionPhase.Started)
        {
            // ���@���g���Ȃ��ꍇ�͏I��
            if (!canMagic) { return; }

            // �N�[���^�C�����I����Ă���
            if (magicCoolTimer >= magicCoolTime)
            {
                // �^�C�}�[�̃��Z�b�g
                magicCoolTimer = 0.0f;

                // �v���n�u��null����Ȃ����
                if (magicPrefab != null)
                {
                    // ���@�𐶐�
                    Instantiate(magicPrefab, transform.position, transform.rotation);
                }
            }
        }
    }
}
