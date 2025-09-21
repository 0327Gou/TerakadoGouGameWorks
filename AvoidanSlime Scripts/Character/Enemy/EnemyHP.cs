/*
 * ファイル：EnemyHP C#
 * システム：敵の移動処理
 * Created by 寺門 冴羽
 * 2025年 一部変更
 */

using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //-------------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //-------------------------------------------------------------------------------------------------------------------------------

    int maxHP;      // 最大HP
    int nowHP;      // 現在のHP
    int oldHP;      // 一つ前のHP

    [SerializeField] float redBarDelayTime;   // 赤HPが減るまでの時間
    float redBarDelayTimer;                   // 赤HPが減るまでのタイマー
    
    Image _GreenHPBar;  // 緑HPバー格納用
    Image _RedHPBar;    // 赤HPバー格納用
    
    AudioSource _as;    // オーディオソース

    //-------------------------------------------------------------------------------------------------------------------------------
    // メイン関数
    //-------------------------------------------------------------------------------------------------------------------------------

    // 最初のフレームの処理
    void Start()
    {
        // コンポーネントの取得
        _as = GetComponent<AudioSource>();

        // 各HPバーを取得
        _GreenHPBar = GameObject.Find("EnemyGreenHPBar").GetComponent<Image>();
        _RedHPBar = GameObject.Find("EnemyRedHPBar").GetComponent<Image>();

        // HPの初期設定
        // ステージデータからステージ番号を取得
        StageDataSettings stageData = (StageDataSettings)Resources.Load("! StageData");
        int stageNumber = stageData.GetStageNumber();

        // ステージ番号からエネミーデータの最大Hpを取得
        StageDataSettings.EnemyData enemyData = stageData.GetEnemyData(stageNumber);
        maxHP = enemyData.maxHp;

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

    //-------------------------------------------------------------------------------------------------------------------------------
    // サブ関数
    //-------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：HPバーを少し遅らせて減らす関数
    /// 引数    ：なし
    /// 戻り値　：なし
    /// </summary>
    void HPBarDelayDamage()
    {
        // HPが減ってたら進む
        if (oldHP > nowHP)
        {
            // 減ってからの時間を計測
            redBarDelayTimer += Time.deltaTime;

            // ディレイタイムが終わったら
            if (redBarDelayTimer >= redBarDelayTime)
            {
                // oldHPにゆっくりとHPを減らす
                --oldHP;

                // 減らしすぎか判定
                if (oldHP < nowHP)
                {
                    // 補正
                    oldHP = nowHP;
                }

                // HPが減り切ったか判定
                if (oldHP <= nowHP)
                {
                    // タイマーをリセット
                    redBarDelayTimer = 0;
                }

                // oldHPをRedHPBarに反映
                _RedHPBar.fillAmount = (float)oldHP / (float)maxHP;
            }
        }
    }

    //-------------------------------------------------------------------------------------------------------------------------------
    // パブリック関数
    //-------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：ダメージを与える関数
    /// 引数    ：_damage：ダメージ量
    /// 戻り値　：なし
    /// </summary>
    public void AddDamage(int _damage)
    {
        // HPを減らす
        nowHP -= _damage;
        //Debug.Log("EnemyHP" + nowHP);

        // ダメージ音を出す
        _as.PlayOneShot(_as.clip);

        // GreenHPバーを減らす
        _GreenHPBar.fillAmount = (float)nowHP / (float)maxHP;

        // ダメージを受けたら減るまでのタイマーをリセット
        redBarDelayTimer = 0;

        // HPがなくなったら
        if (nowHP <= 0) 
        {
            // マネージャーのゲームステータスをゲームクリアに変更
            GameManager script = GameObject.Find("GameManager").GetComponent<GameManager>();
            script.SetGameStatus(GameManager.GameStatus.GameClear);
        }
    }
}