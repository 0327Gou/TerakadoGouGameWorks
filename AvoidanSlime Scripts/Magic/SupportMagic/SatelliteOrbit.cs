/*
* ファイル：SatelliteOrbit C#
* システム：ターゲットを中心として衛星のように周回軌道させるスクリプト
*           周回する時はターゲットを右側として上方向を進行方向に向ける
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteOrbit : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] 
    float m_fRadius;    // 半径（惑星との距離）

    [SerializeField]
    float m_fSpeed;     // 速度（周回速度）

    [SerializeField, Range(0.0f, 360.0f)] 
    float m_fPhi;       // 角度（初期位置、初期位相）

    [SerializeField]
    string targetTag;   // ターゲットのタグ（惑星、回転の中心、回転軸）

    float m_fPhiPI;     // 位相

    GameObject m_obAxis;    // ターゲットのゲームオブジェクト


    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    void Start()
    {
        // ターゲットをタグで取得
        m_obAxis = GameObject.FindWithTag(targetTag);

        // 位相の計算と反映
        m_fPhiPI = (m_fPhi * Mathf.PI) / 180;
    }

    // 毎フレームの処理
    void Update()
    {
        // X軸とY軸の設定
        float m_fX = m_fRadius * Mathf.Sin(Time.time * m_fSpeed + m_fPhiPI);
        float m_fY = m_fRadius * Mathf.Cos(Time.time * m_fSpeed + m_fPhiPI);

        // 座標を動かす
        transform.position = new Vector3(m_fX + m_obAxis.transform.position.x, m_fY + m_obAxis.transform.position.y);

        // ターゲットの方向を取得
        Vector2 lookDir = transform.position - m_obAxis.transform.position;

        // ターゲットの位置を右に向く。進行方向を向くようになる
        transform.rotation = Quaternion.FromToRotation(Vector3.right, lookDir);
    }
}
