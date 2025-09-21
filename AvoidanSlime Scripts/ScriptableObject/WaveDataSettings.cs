/*
* �t�@�C���FWaveDataSettings C#
* �V�X�e���F�E�F�[�u�f�[�^��ScriptableObject�̒�`
* 
* Created by ���� ��H
* 2025�N �ꕔ�ύX
*/

using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "MyScriptable/WaveData")]
public class WaveDataSettings : ScriptableObject
{
    //----------------------------------------------------------------------------------------------------------------------------
    // �ϐ��錾
    //----------------------------------------------------------------------------------------------------------------------------

    // �E�F�[�u�f�[�^�̍\����
    [System.Serializable]
    public struct WaveData
    {
        // �E�F�[�u�̌p������
        public float waveTime;

        // �o�������閂�@�̈ʒu
        public Vector3 magicPosition;

        // �o�������閂�@�̉�]
        public Vector3 magicRotation;

        // �o�������閂�@�̃v���n�u
        public GameObject magicPrefab;
    }

    public WaveData[] waveDataArray;    // �\���̔z��
}
