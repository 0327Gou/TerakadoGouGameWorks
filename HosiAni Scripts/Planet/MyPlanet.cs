using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MyPlanet : MonoBehaviour
{
    // カメラを切り替えるフラグ
    [HideInInspector]
    public bool _fCamChange = false;

    // 自分の惑星の座標
    private Vector3 _PosPlanet;

    //メインカメラ格納用
    private Camera m_camMain;

    //自惑星カメラ格納用
    private Camera m_camMyPlanet;

    // オブジェクトのレンダラー
    private SpriteRenderer _ren;

    // Texture保存用の変数
    private Sprite _MyPlanet_Piace;
    
    // 画像フォルダの名前
    //private string _TexName; 

    // プラネットピースの数
    private int _iNumPiece = 0;

    // メニューキャンバス
    public Canvas MenuCanvas;

    Menu MenuScripts;

    //呼び出し時に実行される関数
    void Start()
    {
        //メインカメラとサブカメラをそれぞれ取得
        m_camMain = GameObject.Find("Camera_Main").GetComponent<Camera>();
        m_camMyPlanet = GameObject.Find("Camera_MyPlanet").GetComponent<Camera>();

        m_camMain.depth = 1;

        // 自分の惑星の位置を取得
        _PosPlanet = GameObject.Find("MyPlanet").transform.position;

        // メニューのスクリプトを持ってくる
        MenuScripts = MenuCanvas.GetComponent<Menu>();
    }

    //単位時間ごとに実行される関数
    void Update()
    {
        if (_fCamChange)
        {
            PlanetSystem();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _fCamChange = true;

            Time.timeScale = 0;  // 時間停止

            // カメラの切り替え
            m_camMain.depth *= -1;
            m_camMyPlanet.depth *= -1;
            Debug.Log("CamChange_Planet");

            // インベントリを表示する
            MenuScripts.inventry.SetActive(true);
        } 
    }

    private void PlanetSystem()
    {
        // Debug.Log("Menu");

        if (_iNumPiece < 6)
        {
            // カメラの切り替え
            if (Input.GetKeyDown("space"))
            {
                // メニューを閉じる
                _fCamChange = false;

                Time.timeScale = 1;  // 再開

                //メインカメラをアクティブに設定
                //_Camera_MyPlanet.SetActive(false);
                //mainCamera.SetActive(true);
                m_camMain.depth *= -1;
                m_camMyPlanet.depth *= -1;

                Debug.Log("CamChange_Player");

                // インベントリを非表示にする
                MenuScripts.inventry.SetActive(false);
            }
        }
        else
        {
            // ゲームクリアの処理
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}
