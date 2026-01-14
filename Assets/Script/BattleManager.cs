using UnityEngine;
using UnityEngine.SceneManagement; // シーン移動に必要

public class BattleManager : MonoBehaviour
{
    public BattleParameter playerStatus;
    public BattleParameter enemyStatus;
    public StatusUIController playerUI;
    public EnemyUIController enemyUI;

    void Start()
    {
        // --- HPの自動初期化（テストを楽にする機能） ---
        if (playerStatus != null && playerStatus.Data != null)
        {
            // 現在のHPを最大HPと同じにする
            playerStatus.Data.HP = playerStatus.Data.MaxHP;
        }

        if (enemyStatus != null && enemyStatus.Data != null)
        {
            // 敵も同様に最大HPで開始
            enemyStatus.Data.HP = enemyStatus.Data.MaxHP;
        }

        // UIを表示に反映
        if (playerUI != null) playerUI.RefreshUI();
        if (enemyUI != null) enemyUI.RefreshUI();
    }

    public void OnAttackButton()
    {
        if (playerStatus == null || enemyStatus == null) return;

        // プレイヤーの攻撃処理
        int bonus = (playerStatus.Data.AttackWeapon != null) ? playerStatus.Data.AttackWeapon.Power: 0;
        int damage = Mathf.Max(1, (playerStatus.Data.AttackPower + bonus) - enemyStatus.Data.DefensePower);

        enemyStatus.Data.HP -= damage;
        if (enemyStatus.Data.HP < 0) enemyStatus.Data.HP = 0;

        if (enemyUI != null) enemyUI.RefreshUI();

        // 勝利判定
        if (enemyStatus.Data.HP <= 0)
        {
            Debug.Log("Victory!");
            Invoke("GoToGameClear", 1.0f);
        }
        else
        {
            Invoke("ExecuteEnemyTurn", 1.0f);
        }
    }

    void ExecuteEnemyTurn()
    {
        if (playerStatus == null || enemyStatus == null) return;

        // 敵の攻撃パターン（前回作成したもの）
        int pattern = Random.Range(0, 3);
        int damage = 0;
        int atk = enemyStatus.Data.AttackPower;
        int def = playerStatus.Data.DefensePower;

        switch (pattern)
        {
            case 0: damage = Mathf.Max(1, atk - def); break;
            case 1: damage = Mathf.Max(1, (int)(atk * 1.5f) - def); break;
            case 2: damage = 10; break;
        }

        playerStatus.Data.HP -= damage;
        if (playerStatus.Data.HP < 0) playerStatus.Data.HP = 0;

        if (playerUI != null) playerUI.RefreshUI();

        // --- 敗北判定（プレイヤーが死んだかチェック） ---
        if (playerStatus.Data.HP <= 0)
        {
            Debug.Log("Player Dead...");
            // 1秒後にゲームオーバーシーンへ
            Invoke("GoToGameOver", 1.0f);
        }
    }

    // シーン移動用メソッド
    void GoToGameClear() => SceneManager.LoadScene("GameClear");
    void GoToGameOver() => SceneManager.LoadScene("GameOver");
}
