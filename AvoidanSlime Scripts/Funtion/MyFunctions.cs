/*
* ファイル：MyFunction C#
* システム：いろいろなスクリプトで多様する関数を定義する
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;

public class MyFunctions : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // パブリック関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：直線移動する関数
    /// 引数    ：_moveSpeed：移動速度
    /// 戻り値　：なし
    /// </summary>
    public void StraightMove(float _moveSpeed)
    {
        // Rigidbody2Dを取得
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // 移動速度を反映（オブジェクトから見て上方向）
        rb.velocity = transform.up * _moveSpeed * Time.timeScale;
    }

    /// <summary>
    /// システム：ターゲットを追いかける関数
    /// 引数    ：_target：追いかける対象
    ///         ：_moveSpeed：移動速度
    /// 戻り値　：なし
    /// </summary>
    public void ChaseToTarget(GameObject _target, float _moveSpeed)
    {
        //Rigidbodyの取得
        Rigidbody2D _rb = gameObject.GetComponent<Rigidbody2D>();

        // 向きの計算（Z成分の除去と正規化）
        Vector3 moveForward = Vector3.Scale((_target.transform.position - transform.position), new Vector3(1, 1, 0)).normalized;

        // 指定の場所に移動、velocityに速度を加える
        _rb.velocity = moveForward * _moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// システム：ターゲットへの向きを求める関数
    /// 引数    ：_target：対象
    /// 戻り値　：Quaternion
    /// </summary>
    public Quaternion RotateTarget(GameObject _target)
    {
        // 戻り値
        Quaternion qResult = Quaternion.identity;

        // ターゲットの方向を取得
        Vector2 lookDir = _target.transform.position - transform.position;

        // ターゲットの方向を計算
        qResult = Quaternion.FromToRotation(Vector3.up, lookDir);

        // 値を返す
        return qResult;
    }

    /// <summary>
    /// システム：プレイヤーへの向きを求める関数
    /// 引数    ：なし
    /// 戻り値　：Quaternion
    /// </summary>
    public Quaternion RotatePlayer()
    {
        // 戻り値
        Quaternion Result = Quaternion.identity;

        // プレイヤーを取得
        GameObject player = GameObject.FindWithTag("Player");

        // ターゲットの方向を取得
        Vector2 lookDir = player.transform.position - transform.position;

        // ターゲットの方向を計算
        Result = Quaternion.FromToRotation(Vector3.up, lookDir);

        // 値を返す
        return Result;
    }

    /// <summary>
    /// システム：ターゲットへ向く関数
    /// 引数    ：_target：対象
    ///         ：_rotateSpeed：回転速度
    /// 戻り値　：なし
    /// </summary>
    public void Homing(GameObject _target, float _rotateSpeed)
    {
        // ターゲットの位置を取得して追尾
        Vector3 pos = _target.transform.position;

        // Rigidbodyの取得
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        // 向きの生成（Z成分の除去と正規化）
        Vector3 moveForward = Vector3.Scale((pos - transform.position), new Vector3(1, 1, 0)).normalized;

        // 指定の場所に移動、velocityに速度を加える
        rb.velocity = moveForward * _rotateSpeed * Time.deltaTime;
    }

    /// <summary>
    /// システム：parent直下の子オブジェクトをforループで取得する関数
    /// 引数    ：_target：対象
    /// 戻り値　：Quaternion
    /// </summary>
    public Transform[] GetChildren(Transform _parent)
    {
        // 子オブジェクトを格納する配列作成
        var children = new Transform[_parent.childCount];

        // 0～個数-1までの子を順番に配列に格納
        for (var i = 0; i < children.Length; ++i)
        {
            children[i] = _parent.GetChild(i);
        }

        // 子オブジェクトが格納された配列
        return children;
    }
}
