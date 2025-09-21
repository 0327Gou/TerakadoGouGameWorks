/*
* ファイル：GameManager C#
* システム：ゲームの進行を管理する
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// ゲームのステータスの定義
    /// </summary>
    public enum GameStatus
    {
        Game,
        GameClear,
        GameOver,
    };

    GameStatus m_gameStatus;    // ゲームのステータス
    
    StageDataSettings m_stageData = null;       // ステージデータ
    StageDataSettings.EnemyData m_enemyData;    // エネミーデータ
    WaveDataSettings.WaveData[] m_waveData;     // ウェーブデータ

    int m_nowWaveNumber;    // 現在のウェーブ数
    int m_waveCount;        // 現在のウェーブカウント
    float m_waveTimer;      // ウェーブ用タイマー
    Text m_waveCountText;   // ウェーブカウント用のテキストオブジェクト


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    void Start()
    {
        // 初期化
        m_gameStatus = GameStatus.Game;
        m_nowWaveNumber = 0;
        m_waveTimer = 0;
        m_waveCount = 0;

        // ステージ番号の取得
        m_stageData = (StageDataSettings)Resources.Load("! StageData");
        int stageNumber = m_stageData.GetStageNumber();

        // エネミーデータの取得
        if (m_stageData != null)
        {
            m_enemyData = m_stageData.GetEnemyData(stageNumber);
        }

        // ウェーブデータの取得
        m_waveData = m_enemyData.waveData.waveDataArray;

        // BGMの変更と再生
        AudioSource _as = GetComponent<AudioSource>();
        _as.clip = m_enemyData.BGM;
        _as.Play();

        // ウェーブテキストの取得
        m_waveCountText = GameObject.Find("WaveCountText").GetComponent<Text>();
        m_waveCountText.text = ("0 ウェーブ");

        // UIの敵の名前をエネミーデータの名前に変更
        GameObject _text = GameObject.Find("EnemyName");
        _text.GetComponent<Text>().text = m_enemyData.enemyName;

        // ステージ番号の敵の出現させる
        // ステージを検索して取得
        Transform _stage = GameObject.Find("Stage").transform;

        // 子オブジェクトを取得する
        Transform[] children = GetChildren(_stage);
        
        // 指定のステージオブジェクトを起動
        children[stageNumber].gameObject.SetActive(true);
    }

    // 毎フレームの処理
    private void Update()
    {
        Wave();
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // サブ宣言
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：ウェーブを進行させる関数
    /// 引数    ：なし
    /// 戻り値　：なし
    /// </summary>
    void Wave()
    {
        // ウェーブデータがnullなら終了
        if (m_enemyData.waveData == null) { return; }

        // 攻撃の発動
        if ((m_waveTimer == 0.0f) && (m_waveData[m_nowWaveNumber].magicPrefab != null))
        {
            // 魔法のプレハブを生成
            Instantiate(m_waveData[m_nowWaveNumber].magicPrefab,
                        m_waveData[m_nowWaveNumber].magicPosition,
                        Quaternion.Euler(m_waveData[m_nowWaveNumber].magicRotation));
        }

        // 時間を計測
        m_waveTimer += Time.deltaTime;

        // 時間経過で次の攻撃に進む
        if (m_waveTimer >= m_waveData[m_nowWaveNumber].waveTime)
        {
            // タイマーのリセット
            m_waveTimer = 0.0f;

            // ウェーブ数を追加
            ++m_nowWaveNumber;
            ++m_waveCount;

            // ウェーブのテキストを更新
            m_waveCountText.text = (m_waveCount + " ウェーブ");
        }

        // ウェーブをループさせる
        if (m_nowWaveNumber >= m_waveData.Length)
        {
            // ウェーブを最初に戻す
            m_nowWaveNumber = 0;
        }
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // パブリック関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：ゲームのステータスを設定
    /// 引数    ：_status ゲームのステータス
    /// 戻り値　：なし
    /// </summary>
    public void SetGameStatus(GameStatus _status)
    {
        // ステータスの設定
        m_gameStatus = _status;

        // ステータスごとの処理
        switch (m_gameStatus)
        {
            // ステータスがデフォルト（Game）なら終了
            default:
                break;

            case GameStatus.GameClear:
                // Debug.Log("GameClear");

                // ステージクリアのシーンに移行
                SceneManager.LoadScene("StageClear");
                break;

            case GameStatus.GameOver:
                // Debug.Log("GameOver");

                // ゲームオーバーのシーンに移行
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
}
