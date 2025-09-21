/*
* ファイル：WaveDataSettings C#
* システム：ウェーブデータのScriptableObjectの定義
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "MyScriptable/WaveData")]
public class WaveDataSettings : ScriptableObject
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    // ウェーブデータの構造体
    [System.Serializable]
    public struct WaveData
    {
        // ウェーブの継続時間
        public float waveTime;

        // 出現させる魔法の位置
        public Vector3 magicPosition;

        // 出現させる魔法の回転
        public Vector3 magicRotation;

        // 出現させる魔法のプレハブ
        public GameObject magicPrefab;
    }

    public WaveData[] waveDataArray;    // 構造体配列
}
