/*
* ファイル：Attack C#
* システム：攻撃のベースとなる処理
* 
* Created by 寺門 冴羽
* 2025年 一部変更
*/

using UnityEngine;

public class Attack : MyFunctions
{
    //----------------------------------------------------------------------------------------------------------------------------
    // 変数宣言
    //----------------------------------------------------------------------------------------------------------------------------
        
    [SerializeField]
    int damage;     // ダメージ
    
    [SerializeField]
    protected bool canEnemyDamage;  // 敵にダメージを与えるか？


    //----------------------------------------------------------------------------------------------------------------------------
    // サブ関数
    //----------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// システム：攻撃力を2倍にする関数
    /// 引数    ：なし
    /// 戻り値　：なし
    /// </summary>
    public void Enhance()
    {
        // 魔法陣
        damage *= 2;
        //Debug.Log("2倍になった");
    }


    //----------------------------------------------------------------------------------------------------------------------------
    // イベント関数
    //----------------------------------------------------------------------------------------------------------------------------

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // タグがプレイヤーなら処理する
        if (collision.gameObject.tag == "Player")
        {
            // プレイヤーのHPを取得してダメージを与える
            PlayerHP _HP = collision.GetComponent<PlayerHP>();
            _HP.AddDamage(damage);
        }

        // 許可がないなら終了
        if (!canEnemyDamage) { return; }

        // タグがエネミーなら処理する
        if (collision.gameObject.tag == "Enemy")
        {
            // 敵のHPを取得してダメージを与える
            EnemyHP _HP = collision.GetComponent<EnemyHP>();
            _HP.AddDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 壁に触れたら消滅
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
