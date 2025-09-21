/*
* ファイル：PlayerHP C#
* システム：プレイヤーのHPを管理する
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    [SerializeField]
    int maxHP;  // 最大HP
    int nowHP;  // 現在のHP
    int oldHP;  // 一つ前のHP

    [SerializeField]
    float redBarDelayTime;      // 赤HPが減るまでの時間
    float redBarDelayTimer;     // 赤HPが減るまでのタイマー

    Image _GreenHPBar;  // 緑HPバーを入れる
    Image _RedHPBar;    // 赤HPバーを入れる
    
    AudioSource _as;    // オーディオソース

    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    void Start()
    {
        // コンポーネントの取得
        _as = GetComponent<AudioSource>();

        // 各HPバーを取得
        _GreenHPBar = GameObject.Find("PlayerGreenHPBar").GetComponent<Image>();
        _RedHPBar = GameObject.Find("PlayerRedHPBar").GetComponent<Image>();

        // 現在のHPを最大HPと同じに。
        nowHP = maxHP;
        oldHP = nowHP;

        // 各HPバーを満タンにする。
        _GreenHPBar.fillAmount = 1;
        _RedHPBar.fillAmount = 1;
    }

    // 毎フレームの処理
    private void Update()
    {
        HPBarDelayDamage();
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // サブ関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：ディレイをかけてHPバーを減らす関数
    /// 引数    ：なし
    /// 戻り値　：なし
    /// </summary>
    void HPBarDelayDamage()
    {
        // HPが減ってる時だけ処理
        if (oldHP > nowHP)
        {
            // 減ってからの時間を計測
            redBarDelayTimer += Time.deltaTime;

            // ディレイタイムが終わったら
            if (redBarDelayTimer >= redBarDelayTime)
            {
                // oldHPにゆっくりとHPを反映
                --oldHP;

                // 減らしすぎたら補正
                if (oldHP < nowHP)
                {
                    oldHP = nowHP;
                }

                // HPが減り切ったらタイマーをリセット
                if (oldHP <= nowHP)
                {
                    redBarDelayTimer = 0;
                }

                // oldHPをRedHPBarに反映
                _RedHPBar.fillAmount = (float)oldHP / (float)maxHP;
            }
        }
    }

    //----------------------------------------------------------------------------------------------------------------------------
    // パブリック関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：ダメージを与える関数
    /// 引数    ：_damage ダメージ量
    /// 戻り値　：なし
    /// </summary>
    public void AddDamage(int _damage)
    {
        // HPを減らす
        nowHP -= _damage;
        //Debug.Log("PlayerHP" + nowHP);

        // ダメージ音を出す
        _as.PlayOneShot(_as.clip);

        // GreenHPバーを減らす
        _GreenHPBar.fillAmount = (float)nowHP / (float)maxHP;

        // ダメージを受けたら減るまでのタイマーをリセット
        redBarDelayTimer = 0;

        // HPがなくなった処理
        if (nowHP <= 0)
        {
            // マネージャーのゲームステータスをゲームオーバーに
            GameManager script = GameObject.Find("GameManager").GetComponent<GameManager>();
            script.SetGameStatus(GameManager.GameStatus.GameOver);
        }
    }
}
