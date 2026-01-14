//using UnityEngine;
//using TMPro;

//public class StatusUIController : MonoBehaviour
//{
//    public GameObject window;
//    public BattleParameter playerStatusData; // ScriptableObject directly

//    public TextMeshProUGUI hpText;
//    public TextMeshProUGUI lvText;
//    public TextMeshProUGUI atkText;

//    void Start()
//    {
//        if (window != null) window.SetActive(false);
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Tab))
//        {
//            if (window == null) return;
//            bool isActive = !window.activeSelf;
//            window.SetActive(isActive);

//            if (isActive) RefreshUI();
//        }
//    }

//    void RefreshUI()
//    {
//        if (playerStatusData == null) return;
//        var data = playerStatusData.Data;


//        if (hpText != null) hpText.text = $"HP: {data.HP} / {data.MaxHP}";
//        if (lvText != null) lvText.text = $"Level: {data.Level}";
//        if (atkText != null) atkText.text = $"Attack: {data.AttackPower}";
//    }
//}
//using UnityEngine;
//using TMPro; // TextMeshProを使っている場合。通常のTextなら using UnityEngine.UI;

//public class StatusUIController : MonoBehaviour
//{
//    public BattleParameter parameter; // 読み込むデータアセット

//    // Hierarchyにある各オブジェクトをドラッグ＆ドロップで紐付けます
//    public TextMeshProUGUI hpText;
//    public TextMeshProUGUI atText;
//    public TextMeshProUGUI lvText;

//    void Start()
//    {
//        RefreshUI();
//    }

//    // 数値を最新の状態に更新するメソッド
//    public void RefreshUI()
//    {
//        if (parameter == null) return;

//        // 数値を文字列にしてUIに反映
//        if (hpText != null) hpText.text = "HP: " + parameter.Data.HP + " / " + parameter.Data.MaxHP;
//        if (atText != null) atText.text = "AT: " + parameter.Data.AttackPower;
//        if (lvText != null) lvText.text = "Lv: " + parameter.Data.Level;
//    }
//}
using UnityEngine;
using TMPro;

public class StatusUIController : MonoBehaviour
{
    [Header("表示・非表示を切り替えるStatusWindow")]
    public GameObject window;

    [Header("ステータスデータのアセット")]
    public BattleParameter playerStatusData;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI lvText;
    public TextMeshProUGUI atkText;

    void Start()
    {
        // 起動時にWindowを隠す
        if (window != null) window.SetActive(false);
    }

    void Update()
    {
        // Tabキーで切り替え
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (window == null) return;

            bool isActive = !window.activeSelf;
            window.SetActive(isActive);

            // 表示される瞬間に数値を更新
            if (isActive) RefreshUI();
        }
    }

    // 他のスクリプト（BattleManagerなど）からも呼べるように public にします
    public void RefreshUI()
    {
        if (playerStatusData == null || playerStatusData.Data == null) return;
        var data = playerStatusData.Data;

        // 1. HPの表示
        if (hpText != null) hpText.text = $"HP: {data.HP} / {data.MaxHP}";

        // 2. レベルの表示
        if (lvText != null) lvText.text = $"Level: {data.Level}";

        // 3. 伝説の剣のボーナスを含めた攻撃力を計算
        int bonus = (data.AttackWeapon != null) ? data.AttackWeapon.Power : 0;
        int totalAtk = data.AttackPower + bonus; // 既に武器のPowerはAttackPowerに含まれています

        if (atkText != null) atkText.text = $"Attack: {totalAtk}";
    }
}