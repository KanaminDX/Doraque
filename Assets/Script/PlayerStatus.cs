//using UnityEngine;

//public class PlayerStatus : MonoBehaviour
//{
//    // エディタで作成した原本をセットする
//    public BattleParameter statusTemplate;

//    // ゲーム中に変動する値を入れるための実体
//    public BattleParameterBase currentStatus = new BattleParameterBase();

//    void Awake()
//    {
//        if (statusTemplate != null)
//        {
//            // 原本（ScriptableObject）からゲーム用の実体にコピーする
//            // これをしないと、ゲーム中にHPが減った時に原本のファイルまで書き換わってしまいます
//            statusTemplate.Data.CopyTo(currentStatus);

//            Debug.Log($"プレイヤーの攻撃力: {currentStatus.AttackPower}");
//        }
//    }
//}
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public BattleParameter statusTemplate;
    public BattleParameterBase currentStatus = new BattleParameterBase();

    void Awake()
    {
        if (statusTemplate != null)
        {
            statusTemplate.Data.CopyTo(currentStatus);
            Debug.Log($"プレイヤーの攻撃力: {currentStatus.AttackPower}");
        }
    }

    // --- 追加：武器を装備する処理 ---
    public void EquipWeapon(Weapon newWeapon)
    {
        if (newWeapon.Kind == WeaponKind.Attack)
        {
            // 1. 実行中のステータスにセット
            currentStatus.AttackWeapon = newWeapon;

            // 2. BattleManagerが参照している原本データにもセット（戦闘シーンで反映させるため）
            statusTemplate.Data.AttackWeapon = newWeapon;

            Debug.Log($"{newWeapon.Name} を装備！ 攻撃力が {newWeapon.Power} 加算されます。");
        }
    }
}