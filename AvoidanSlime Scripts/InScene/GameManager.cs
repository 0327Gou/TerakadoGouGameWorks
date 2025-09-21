/*
* �t�@�C���FGameManager C#
* �V�X�e���F�Q�[���̐i�s���Ǘ�����
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �Q�[���̃X�e�[�^�X�̒�`
    /// </summary>
    public enum GameStatus
    {
        Game,
        GameClear,
        GameOver,
    };

    GameStatus m_gameStatus;    // �Q�[���̃X�e�[�^�X
    
    StageDataSettings m_stageData = null;       // �X�e�[�W�f�[�^
    StageDataSettings.EnemyData m_enemyData;    // �G�l�~�[�f�[�^
    WaveDataSettings.WaveData[] m_waveData;     // �E�F�[�u�f�[�^

    int m_nowWaveNumber;    // ���݂̃E�F�[�u��
    int m_waveCount;        // ���݂̃E�F�[�u�J�E���g
    float m_waveTimer;      // �E�F�[�u�p�^�C�}�[
    Text m_waveCountText;   // �E�F�[�u�J�E���g�p�̃e�L�X�g�I�u�W�F�N�g


    //----------------------------------------------------------------------------------------------------------------------------
    // ���C���֐�
    //----------------------------------------------------------------------------------------------------------------------------

    // �ŏ��̃t���[���̏���
    void Start()
    {
        // ������
        m_gameStatus = GameStatus.Game;
        m_nowWaveNumber = 0;
        m_waveTimer = 0;
        m_waveCount = 0;

        // �X�e�[�W�ԍ��̎擾
        m_stageData = (StageDataSettings)Resources.Load("! StageData");
        int stageNumber = m_stageData.GetStageNumber();

        // �G�l�~�[�f�[�^�̎擾
        if (m_stageData != null)
        {
            m_enemyData = m_stageData.GetEnemyData(stageNumber);
        }

        // �E�F�[�u�f�[�^�̎擾
        m_waveData = m_enemyData.waveData.waveDataArray;

        // BGM�̕ύX�ƍĐ�
        AudioSource _as = GetComponent<AudioSource>();
        _as.clip = m_enemyData.BGM;
        _as.Play();

        // �E�F�[�u�e�L�X�g�̎擾
        m_waveCountText = GameObject.Find("WaveCountText").GetComponent<Text>();
        m_waveCountText.text = ("0 �E�F�[�u");

        // UI�̓G�̖��O���G�l�~�[�f�[�^�̖��O�ɕύX
        GameObject _text = GameObject.Find("EnemyName");
        _text.GetComponent<Text>().text = m_enemyData.enemyName;

        // �X�e�[�W�ԍ��̓G�̏o��������
        // �X�e�[�W���������Ď擾
        Transform _stage = GameObject.Find("Stage").transform;

        // �q�I�u�W�F�N�g���擾����
        Transform[] children = GetChildren(_stage);
        
        // �w��̃X�e�[�W�I�u�W�F�N�g���N��
        children[stageNumber].gameObject.SetActive(true);
    }

    // ���t���[���̏���
    private void Update()
    {
        Wave();
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // �T�u�錾
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�E�F�[�u��i�s������֐�
    /// ����    �F�Ȃ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    void Wave()
    {
        // �E�F�[�u�f�[�^��null�Ȃ�I��
        if (m_enemyData.waveData == null) { return; }

        // �U���̔���
        if ((m_waveTimer == 0.0f) && (m_waveData[m_nowWaveNumber].magicPrefab != null))
        {
            // ���@�̃v���n�u�𐶐�
            Instantiate(m_waveData[m_nowWaveNumber].magicPrefab,
                        m_waveData[m_nowWaveNumber].magicPosition,
                        Quaternion.Euler(m_waveData[m_nowWaveNumber].magicRotation));
        }

        // ���Ԃ��v��
        m_waveTimer += Time.deltaTime;

        // ���Ԍo�߂Ŏ��̍U���ɐi��
        if (m_waveTimer >= m_waveData[m_nowWaveNumber].waveTime)
        {
            // �^�C�}�[�̃��Z�b�g
            m_waveTimer = 0.0f;

            // �E�F�[�u����ǉ�
            ++m_nowWaveNumber;
            ++m_waveCount;

            // �E�F�[�u�̃e�L�X�g���X�V
            m_waveCountText.text = (m_waveCount + " �E�F�[�u");
        }

        // �E�F�[�u�����[�v������
        if (m_nowWaveNumber >= m_waveData.Length)
        {
            // �E�F�[�u���ŏ��ɖ߂�
            m_nowWaveNumber = 0;
        }
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // �p�u���b�N�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�Q�[���̃X�e�[�^�X��ݒ�
    /// ����    �F_status �Q�[���̃X�e�[�^�X
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void SetGameStatus(GameStatus _status)
    {
        // �X�e�[�^�X�̐ݒ�
        m_gameStatus = _status;

        // �X�e�[�^�X���Ƃ̏���
        switch (m_gameStatus)
        {
            // �X�e�[�^�X���f�t�H���g�iGame�j�Ȃ�I��
            default:
                break;

            case GameStatus.GameClear:
                // Debug.Log("GameClear");

                // �X�e�[�W�N���A�̃V�[���Ɉڍs
                SceneManager.LoadScene("StageClear");
                break;

            case GameStatus.GameOver:
                // Debug.Log("GameOver");

                // �Q�[���I�[�o�[�̃V�[���Ɉڍs
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
}
