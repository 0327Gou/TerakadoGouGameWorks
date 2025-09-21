/*
* �t�@�C���FPlayerHP C#
* �V�X�e���F�v���C���[��HP���Ǘ�����
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    int maxHP;  // �ő�HP
    int nowHP;  // ���݂�HP
    int oldHP;  // ��O��HP

    [SerializeField]
    float redBarDelayTime;      // ��HP������܂ł̎���
    float redBarDelayTimer;     // ��HP������܂ł̃^�C�}�[

    Image _GreenHPBar;  // ��HP�o�[������
    Image _RedHPBar;    // ��HP�o�[������
    
    AudioSource _as;    // �I�[�f�B�I�\�[�X

    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    void Start()
    {
        // �R���|�[�l���g�̎擾
        _as = GetComponent<AudioSource>();

        // �eHP�o�[���擾
        _GreenHPBar = GameObject.Find("PlayerGreenHPBar").GetComponent<Image>();
        _RedHPBar = GameObject.Find("PlayerRedHPBar").GetComponent<Image>();

        // ���݂�HP���ő�HP�Ɠ����ɁB
        nowHP = maxHP;
        oldHP = nowHP;

        // �eHP�o�[�𖞃^���ɂ���B
        _GreenHPBar.fillAmount = 1;
        _RedHPBar.fillAmount = 1;
    }

    // ���t���[���̏���
    private void Update()
    {
        HPBarDelayDamage();
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // �T�u�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�f�B���C��������HP�o�[�����炷�֐�
    /// ����    �F�Ȃ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    void HPBarDelayDamage()
    {
        // HP�������Ă鎞��������
        if (oldHP > nowHP)
        {
            // �����Ă���̎��Ԃ��v��
            redBarDelayTimer += Time.deltaTime;

            // �f�B���C�^�C�����I�������
            if (redBarDelayTimer >= redBarDelayTime)
            {
                // oldHP�ɂ�������HP�𔽉f
                --oldHP;

                // ���炵��������␳
                if (oldHP < nowHP)
                {
                    oldHP = nowHP;
                }

                // HP������؂�����^�C�}�[�����Z�b�g
                if (oldHP <= nowHP)
                {
                    redBarDelayTimer = 0;
                }

                // oldHP��RedHPBar�ɔ��f
                _RedHPBar.fillAmount = (float)oldHP / (float)maxHP;
            }
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // �p�u���b�N�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�_���[�W��^����֐�
    /// ����    �F_damage �_���[�W��
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void AddDamage(int _damage)
    {
        // HP�����炷
        nowHP -= _damage;
        //Debug.Log("PlayerHP" + nowHP);

        // �_���[�W�����o��
        _as.PlayOneShot(_as.clip);

        // GreenHP�o�[�����炷
        _GreenHPBar.fillAmount = (float)nowHP / (float)maxHP;

        // �_���[�W���󂯂��猸��܂ł̃^�C�}�[�����Z�b�g
        redBarDelayTimer = 0;

        // HP���Ȃ��Ȃ�������
        if (nowHP <= 0)
        {
            // �}�l�[�W���[�̃Q�[���X�e�[�^�X���Q�[���I�[�o�[��
            GameManager script = GameObject.Find("GameManager").GetComponent<GameManager>();
            script.SetGameStatus(GameManager.GameStatus.GameOver);
        }
    }
}
