/*
 * �t�@�C���FEnemyHP C#
 * �V�X�e���F�G�̈ړ�����
 * Created by ���� ��H
 * 2025�N �ꕔ�ύX
 */

using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //-------------------------------------------------------------------------------------------------------------------------------

    int maxHP;      // �ő�HP
    int nowHP;      // ���݂�HP
    int oldHP;      // ��O��HP

    [SerializeField] float redBarDelayTime;   // ��HP������܂ł̎���
    float redBarDelayTimer;                   // ��HP������܂ł̃^�C�}�[
    
    Image _GreenHPBar;  // ��HP�o�[�i�[�p
    Image _RedHPBar;    // ��HP�o�[�i�[�p
    
    AudioSource _as;    // �I�[�f�B�I�\�[�X

    //-------------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //-------------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    void Start()
    {
        // �R���|�[�l���g�̎擾
        _as = GetComponent<AudioSource>();

        // �eHP�o�[���擾
        _GreenHPBar = GameObject.Find("EnemyGreenHPBar").GetComponent<Image>();
        _RedHPBar = GameObject.Find("EnemyRedHPBar").GetComponent<Image>();

        // HP�̏����ݒ�
        // �X�e�[�W�f�[�^����X�e�[�W�ԍ����擾
        StageDataSettings stageData = (StageDataSettings)Resources.Load("! StageData");
        int stageNumber = stageData.GetStageNumber();

        // �X�e�[�W�ԍ�����G�l�~�[�f�[�^�̍ő�Hp���擾
        StageDataSettings.EnemyData enemyData = stageData.GetEnemyData(stageNumber);
        maxHP = enemyData.maxHp;

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

    //-------------------------------------------------------------------------------------------------------------------------------
    // �T�u�֐�
    //-------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���FHP�o�[�������x�点�Č��炷�֐�
    /// ����    �F�Ȃ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    void HPBarDelayDamage()
    {
        // HP�������Ă���i��
        if (oldHP > nowHP)
        {
            // �����Ă���̎��Ԃ��v��
            redBarDelayTimer += Time.deltaTime;

            // �f�B���C�^�C�����I�������
            if (redBarDelayTimer >= redBarDelayTime)
            {
                // oldHP�ɂ�������HP�����炷
                --oldHP;

                // ���炵����������
                if (oldHP < nowHP)
                {
                    // �␳
                    oldHP = nowHP;
                }

                // HP������؂���������
                if (oldHP <= nowHP)
                {
                    // �^�C�}�[�����Z�b�g
                    redBarDelayTimer = 0;
                }

                // oldHP��RedHPBar�ɔ��f
                _RedHPBar.fillAmount = (float)oldHP / (float)maxHP;
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
    // �p�u���b�N�֐�
    //-------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�_���[�W��^����֐�
    /// ����    �F_damage�F�_���[�W��
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void AddDamage(int _damage)
    {
        // HP�����炷
        nowHP -= _damage;
        //Debug.Log("EnemyHP" + nowHP);

        // �_���[�W�����o��
        _as.PlayOneShot(_as.clip);

        // GreenHP�o�[�����炷
        _GreenHPBar.fillAmount = (float)nowHP / (float)maxHP;

        // �_���[�W���󂯂��猸��܂ł̃^�C�}�[�����Z�b�g
        redBarDelayTimer = 0;

        // HP���Ȃ��Ȃ�����
        if (nowHP <= 0) 
        {
            // �}�l�[�W���[�̃Q�[���X�e�[�^�X���Q�[���N���A�ɕύX
            GameManager script = GameObject.Find("GameManager").GetComponent<GameManager>();
            script.SetGameStatus(GameManager.GameStatus.GameClear);
        }
    }
}