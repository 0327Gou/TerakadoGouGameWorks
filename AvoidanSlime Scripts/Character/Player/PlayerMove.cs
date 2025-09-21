/*
* ファイル：PlayerMove C#
* システム：プレイヤーの移動処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField] float moveSpeed;    // 調整可能な移動速度

    bool canMove;       // 移動できるか
    Vector2 moveInput;  // インプット用

    SpriteRenderer _groundSprite = null;    // 移動範囲のオブジェクトのスプライト
    Rigidbody2D _rb;                        // Rigidbody2Dの格納用

    //----------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //----------------------------------------------------------------------------------------------------------------------------

    // インスタンスが読み込まれるときの処理
    private void Awake()
    {
        // 初期化
        canMove = true;

        // コンポーネントの取得
        _rb = gameObject.GetComponent<Rigidbody2D>();

        // 移動範囲のオブジェクトを取得
        GameObject _groundObj = GameObject.Find("PlayGround");

        // 移動範囲オブジェクトのスプライトを取得
        if (_groundObj != null)
        {
            // 移動範囲オブジェクトのスプライトを取得
            _groundSprite = _groundObj.GetComponent<SpriteRenderer>();
        }
    }

    // 毎フレームの処理
    void Update()
    {
        // 移動
        Move();

        // 移動制限
        MoveClamp();
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // サブ関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：移動処理
    /// 引数　　：なし
    /// 戻り値　：なし
    /// </summary>
    void Move()
    {
        // 移動できない場合は終了
        if (!canMove) { return; }

        //移動の反映
        _rb.position += moveInput * moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// システム：プレイヤーの行動範囲制限
    /// 引数　　：なし
    /// 戻り値　：なし
    /// </summary>
    void MoveClamp()
    {
        // 行動範囲がないなら終了
        if (_groundSprite == null) { return; }

        // 補正用の変数
        Vector2 ClampVec = transform.position;

        // 画面右上の座標を取得
        Vector2 max = _groundSprite.bounds.max;

        // 画面左下の座標を取得
        Vector2 min = _groundSprite.bounds.min;

        // プレイヤーのサイズを取得
        Vector2 scl = transform.localScale / 2;

        // 枠から出ないように補正
        ClampVec.x = Mathf.Clamp(ClampVec.x, min.x + scl.x, max.x - scl.x);
        ClampVec.y = Mathf.Clamp(ClampVec.y, min.y + scl.y, max.y - scl.y);

        // 補正を反映
        transform.position = ClampVec;
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：移動キーの判定
    /// 引数　　：IA context
    /// 戻り値　：なし
    /// </summary>
    public void IA_Move(InputAction.CallbackContext context)
    {
        // 移動できない場合は終了
        if (!canMove) { return; }

        // Moveアクションの入力取得
        moveInput = context.ReadValue<Vector2>();
        // Debug.Log("入力された値は" + _moveInputValue);

        // 値を補正
        moveInput.Normalize();
    }
}