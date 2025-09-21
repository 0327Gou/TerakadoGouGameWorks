/*
* ファイル：ScenesManager C#
* システム：シーン遷移を管理するスクリプト
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ScenesManager : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    // シーンを定義するenum
    public enum Scenes
    {
        Title,
        Menu,
        Guide,
        GameOver,
        StageClear,
        GameClear,
        End,
        Stage1,
        Stage2,
        Stage3,
    }

    [SerializeField]
    Scenes scenes;                          // 移動先のシーンを選択する調整用変数

    StageDataSettings m_stageData = null;   // ステージデータ格納用

    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // インスタンスが読み込まれた時の処理
    private void Awake()
    {
        // ステージデータを取得
        m_stageData = (StageDataSettings)Resources.Load("! StageData");
        //Debug.Log("Menu set StageData  " + m_stageData.name);

        // ステージデータがないなら
        if (m_stageData == null) 
        {
            // エラーログを出す 
            Debug.LogError("Menu No StageData");
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // サブ関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 指定されたシーンに遷移する関数
    private void GoScene()
    {
        switch (scenes.ToString())
        {
            case "Title":
                // タイトルへ遷移
                SceneManager.LoadScene("Title");
                break;

            case "Menu":
                // メニューへ遷移
                SceneManager.LoadScene("Menu");
                break;

            case "Guide":
                // ガイドへ遷移
                SceneManager.LoadScene("Guide");
                break;

            case "GameOver":
                // ゲームオーバーへ遷移
                SceneManager.LoadScene("GameOver");
                break;

            case "StageClear":
                // クリアへ遷移
                SceneManager.LoadScene("StageClear");
                break;

            case "GameClear":
                // クリアへ遷移
                SceneManager.LoadScene("GameClear");
                break;

            case "End":
                // ゲームの強制終了
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit(); //ゲームプレイ終了
                #endif
                break;

            case "Stage1":
                // ステージ番号の設定
                m_stageData.SetStageNumber(0);
                //Debug.Log(m_stageData.GetStageNumber());

                // ステージ1に移動
                SceneManager.LoadScene("Game");
                break;

            case "Stage2":
                // ステージ番号の設定
                m_stageData.SetStageNumber(1);
                //Debug.Log(m_stageData.GetStageNumber());

                // ステージ2に移動
                SceneManager.LoadScene("Game");
                break;

            case "Stage3":
                // ステージ番号の設定
                m_stageData.SetStageNumber(2);
                //Debug.Log(m_stageData.GetStageNumber());

                // ステージ3に移動
                SceneManager.LoadScene("Game");
                break;
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：インプット入力を検知する関数
    /// 引数    ：パッド操作：SouthButton
    ///         ：キーボードマウス操作：LeftClick
    /// 戻り値　：なし
    /// </summary>
    public void IA_Select(InputAction.CallbackContext context)
    {
        // フェーズがCanceledかの判定を行う
        // Started、Performedだと連続してシーンが移動してしまうため
        if (context.phase == InputActionPhase.Canceled)
        {
            //Debug.Log("GoScene");
            GoScene();
        }
    }

    /// <summary>
    /// システム：UnityButtonの入力を検知する関数
    /// 引数    ：なし
    /// 戻り値　：なし
    /// </summary>
    public void Button_Select()
    {
        // 指定したシーンに移動する関数を呼び出す
        GoScene();
    }
}
