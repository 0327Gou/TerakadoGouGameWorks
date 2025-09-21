/*
* ファイル：PlayerMagic C#
* システム：プレイヤーの魔法処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagic : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float magicCoolTime;             // 魔法のクールタイム
    [SerializeField] GameObject magicPrefab = null;   // 魔法のプレハブ

    bool canMagic;            // 魔法が使えるかのフラグ
    float magicCoolTimer;     // 魔法のクールタイマー

    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    void Start()
    {
        // 初期化
        canMagic = true;
        magicCoolTimer = 0.0f;
    }

    // 毎フレームの処理
    void Update()
    {
        // クールタイムを計測
        magicCoolTimer += Time.deltaTime;
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：魔法の入力を検知して発動する
    /// 引数    ：IA context
    /// 戻り値　：なし
    /// </summary>
    public void IA_Magic(InputAction.CallbackContext context)
    {
        // Performedフェーズの判定を行う
        if (context.phase == InputActionPhase.Started)
        {
            // 魔法が使えない場合は終了
            if (!canMagic) { return; }

            // クールタイムが終わってたら
            if (magicCoolTimer >= magicCoolTime)
            {
                // タイマーのリセット
                magicCoolTimer = 0.0f;

                // プレハブがnullじゃなければ
                if (magicPrefab != null)
                {
                    // 魔法を生成
                    Instantiate(magicPrefab, transform.position, transform.rotation);
                }
            }
        }
    }
}
