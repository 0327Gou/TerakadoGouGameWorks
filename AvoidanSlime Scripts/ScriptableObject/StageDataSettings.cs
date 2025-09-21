/*
* �t�@�C���FStageDataSettings C#
* �V�X�e���F�X�e�[�W�f�[�^��ScriptableObject�̒�`
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "MyScriptable/StageData")]
public class StageDataSettings : ScriptableObject
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    private static int stageNumber;     // �X�e�[�W�ԍ�

    // �G�f�[�^�̍\����
    [System.Serializable]
    public struct EnemyData
    {
        // �G�̖��O
        public string enemyName;

        // �G�̍ő�Hp
        public int maxHp;

        // �G��WaveData
        public WaveDataSettings waveData;

        // �G��BGM
        public AudioClip BGM;
    }

    public EnemyData[] enemyDataArray;      // �\���̔z��


    //----------------------------------------------------------------------------------------------------------------------------
    // �p�u���b�N�֐�
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// �V�X�e���F�X�e�[�W�ԍ����擾���ĕԂ��֐�
    /// ����    �F�Ȃ�
    /// �߂�l�@�FstageNumber�F�X�e�[�W�ԍ�
    /// </summary>
    public int GetStageNumber()
    {
        return stageNumber;
    }

    /// <summary>
    /// �V�X�e���F�X�e�[�W�ԍ���ݒ肷��֐�
    /// ����    �F_stageNumber�F�X�e�[�W�ԍ�
    /// �߂�l�@�F�Ȃ�
    /// </summary>
    public void SetStageNumber(int _stageNumber)
    {
        stageNumber = _stageNumber;
        //Debug.Log("�X�e�[�W�i���o�[��" + stageNumber + "�ɐݒ�");
    }

    /// <summary>
    /// �V�X�e���F�G�f�[�^��Ԃ��֐�
    /// ����    �F_enemyNumber�F�G�̔ԍ�
    /// �߂�l�@�F�G�̃f�[�^
    /// </summary>
    public EnemyData GetEnemyData(int _enemyNumber)
    {
        return enemyDataArray[_enemyNumber];
    }
}
