using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // エディタで作成した原本をセットする
    public BattleParameter statusTemplate;

    // ゲーム中に変動する値を入れるための実体
    public BattleParameterBase currentStatus = new BattleParameterBase();

    void Awake()
    {
        if (statusTemplate != null)
        {
            // 原本（ScriptableObject）からゲーム用の実体にコピーする
            // これをしないと、ゲーム中にHPが減った時に原本のファイルまで書き換わってしまいます
            statusTemplate.Data.CopyTo(currentStatus);

            Debug.Log($"プレイヤーの攻撃力: {currentStatus.AttackPower}");
        }
    }
}