using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public BattleParameter playerStatus;
    public BattleParameter enemyStatus;
    public StatusUIController playerUI;
    public EnemyUIController enemyUI;

    [Header("ログ表示用テキスト")]
    public TextMeshProUGUI logText;

    private bool isPlayerDefending = false;

    void Start()
    {
        if (playerStatus != null && playerStatus.Data != null) playerStatus.Data.HP = playerStatus.Data.MaxHP;
        if (enemyStatus != null && enemyStatus.Data != null) enemyStatus.Data.HP = enemyStatus.Data.MaxHP;

        UpdateAllUI();

        SetLog("戦闘開始！");
    }

    void SetLog(string message)
    {
        if (logText != null)
        {
            logText.text = message;
        }
        Debug.Log(message);
    }

    public void OnAttackButton()
    {
        if (playerStatus == null || enemyStatus == null) return;

        isPlayerDefending = false;

        int bonus = (playerStatus.Data.AttackWeapon != null) ? playerStatus.Data.AttackWeapon.Power : 0;
        int damage = Mathf.Max(1, (playerStatus.Data.AttackPower + bonus) - enemyStatus.Data.DefensePower);

        enemyStatus.Data.HP -= damage;
        if (enemyStatus.Data.HP < 0) enemyStatus.Data.HP = 0;

        UpdateAllUI();

        SetLog($"プレイヤーの攻撃！ 敵に {damage} のダメージを与えた！");

        if (enemyStatus.Data.HP <= 0)
        {
            SetLog("勝利！");
            Invoke("LoadClearScene", 1.0f);
        }
        else
        {
            Invoke("ExecuteEnemyTurn", 1.0f);
        }
    }

    public void OnDefenseButton()
    {

        SetLog("プレイヤーは身を護っている...");
        isPlayerDefending = true;
        Invoke("ExecuteEnemyTurn", 1.0f);
    }

    void ExecuteEnemyTurn()
    {
        if (playerStatus == null || enemyStatus == null) return;

        int pattern = Random.Range(0, 3);
        int damage = 0;
        string attackName = "";


        switch (pattern)
        {
            case 0:
                damage = Mathf.Max(1, enemyStatus.Data.AttackPower - playerStatus.Data.DefensePower);
                attackName = "通常攻撃";
                break;
            case 1:
                damage = Mathf.Max(1, (int)(enemyStatus.Data.AttackPower * 1.5f) - playerStatus.Data.DefensePower);
                attackName = "強烈な一撃";
                break;
            case 2:
                damage = 10;
                attackName = "貫通ビーム";
                break;
        }

        if (isPlayerDefending)
        {
            damage /= 2;

            SetLog($"防御成功！ {attackName} を軽減し、{damage} のダメージに抑えた！");
            isPlayerDefending = false;
        }
        else
        {

            SetLog($"敵の {attackName}！ {damage} のダメージを受けた！");
        }

        playerStatus.Data.HP -= damage;
        if (playerStatus.Data.HP < 0) playerStatus.Data.HP = 0;

        UpdateAllUI();

        if (playerStatus.Data.HP <= 0)
        {
            SetLog("敗北してしまった...");
            Invoke("LoadOverScene", 1.0f);
        }
    }

    void UpdateAllUI()
    {
        if (enemyUI != null) enemyUI.RefreshUI();
        if (playerUI != null) playerUI.RefreshUI();
    }

    void LoadClearScene() => SceneManager.LoadScene("GameClear");
    void LoadOverScene() => SceneManager.LoadScene("GameOver");
}