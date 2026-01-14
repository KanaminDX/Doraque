//using UnityEngine;
//using TMPro;

//public class EnemyUIController : MonoBehaviour
//{
//    public GameObject window;
//    public BattleParameter enemyData;

//    public TextMeshProUGUI nameText;
//    public TextMeshProUGUI hpText;

//    void Start()
//    {
//        window.SetActive(true);
//        RefreshUI();
//    }

//    public void RefreshUI()
//    {
//        if (enemyData == null) return;

//        var data = enemyData.Data;
//        nameText.text = enemyData.name;
//        hpText.text = $"HP: {data.HP} / {data.MaxHP}";
//    }
//}
using UnityEngine;
using TMPro;

public class EnemyUIController : MonoBehaviour
{
    public BattleParameter enemyParameter;
    public TextMeshProUGUI hpText;

    void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (enemyParameter != null && hpText != null)
        {
            hpText.text = "HP: " + enemyParameter.Data.HP;
        }
    }
}