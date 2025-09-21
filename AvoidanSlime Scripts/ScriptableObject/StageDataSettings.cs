/*
* ファイル：StageDataSettings C#
* システム：ステージデータのScriptableObjectの定義
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "MyScriptable/StageData")]
public class StageDataSettings : ScriptableObject
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    private static int stageNumber;     // ステージ番号

    // 敵データの構造体
    [System.Serializable]
    public struct EnemyData
    {
        // 敵の名前
        public string enemyName;

        // 敵の最大Hp
        public int maxHp;

        // 敵のWaveData
        public WaveDataSettings waveData;

        // 敵のBGM
        public AudioClip BGM;
    }

    public EnemyData[] enemyDataArray;      // 構造体配列


    //----------------------------------------------------------------------------------------------------------------------------
    // パブリック関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：ステージ番号を取得して返す関数
    /// 引数    ：なし
    /// 戻り値　：stageNumber：ステージ番号
    /// </summary>
    public int GetStageNumber()
    {
        return stageNumber;
    }

    /// <summary>
    /// システム：ステージ番号を設定する関数
    /// 引数    ：_stageNumber：ステージ番号
    /// 戻り値　：なし
    /// </summary>
    public void SetStageNumber(int _stageNumber)
    {
        stageNumber = _stageNumber;
        //Debug.Log("ステージナンバーを" + stageNumber + "に設定");
    }

    /// <summary>
    /// システム：敵データを返す関数
    /// 引数    ：_enemyNumber：敵の番号
    /// 戻り値　：敵のデータ
    /// </summary>
    public EnemyData GetEnemyData(int _enemyNumber)
    {
        return enemyDataArray[_enemyNumber];
    }
}
