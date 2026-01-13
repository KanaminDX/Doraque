using UnityEngine;
using TMPro;

public class EnemyUIController : MonoBehaviour
{
    public GameObject window;
    public BattleParameter enemyData;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;

    void Start()
    {
        window.SetActive(true);
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (enemyData == null) return;

        var data = enemyData.Data;
        nameText.text = enemyData.name;
        hpText.text = $"HP: {data.HP} / {data.MaxHP}";
    }
}