using UnityEngine;

public class BattleManager : MonoBehaviour
{
   
    public BattleParameter playerStatus;
    public BattleParameter enemyStatus;

   
    public StatusUIController playerUI;
    public EnemyUIController enemyUI;

    public void OnAttackButton()
    {
        if (playerStatus == null || enemyStatus == null) return;

        int damage = Mathf.Max(1, playerStatus.Data.AttackPower - enemyStatus.Data.DefensePower);

        enemyStatus.Data.HP -= damage;
        if (enemyStatus.Data.HP < 0) enemyStatus.Data.HP = 0;

        Debug.Log($"{enemyStatus.name} ‚É {damage} ‚Ìƒ_ƒ[ƒW‚ð—^‚¦‚½I");

        if (enemyUI != null) enemyUI.RefreshUI();

        if (enemyStatus.Data.HP <= 0)
        {
            Debug.Log("“G‚ð“|‚µ‚½I");
        }
    }
}