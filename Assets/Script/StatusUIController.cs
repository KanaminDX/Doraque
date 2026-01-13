using UnityEngine;
using TMPro;

public class StatusUIController : MonoBehaviour
{
    public GameObject window;
    public BattleParameter playerStatusData; // ScriptableObject directly

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI lvText;
    public TextMeshProUGUI atkText;

    void Start()
    {
        if (window != null) window.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (window == null) return;
            bool isActive = !window.activeSelf;
            window.SetActive(isActive);

            if (isActive) RefreshUI();
        }
    }

    void RefreshUI()
    {
        if (playerStatusData == null) return;
        var data = playerStatusData.Data;

       
        if (hpText != null) hpText.text = $"HP: {data.HP} / {data.MaxHP}";
        if (lvText != null) lvText.text = $"Level: {data.Level}";
        if (atkText != null) atkText.text = $"Attack: {data.AttackPower}";
    }
}