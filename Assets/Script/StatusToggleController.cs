using UnityEngine;

public class StatusToggleController : MonoBehaviour
{
    // Hierarchyにある「StatusWindow」（背景やHPテキストが入っている親オブジェクト）
    public GameObject statusWindow;

    // 前に作成した、数値を更新するためのスクリプト
    public StatusUIController uiController;

    void Start()
    {
        // ゲーム開始時はステータス画面を隠しておく
        if (statusWindow != null)
        {
            statusWindow.SetActive(false);
        }
    }

    void Update()
    {
        // Tabキーが押された瞬間を検知
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleStatus();
        }
    }

    public void ToggleStatus()
    {
        if (statusWindow == null) return;

        // 現在の表示状態を反転させる（表示なら非表示、非表示なら表示）
        bool isActive = !statusWindow.activeSelf;
        statusWindow.SetActive(isActive);

        // 画面を表示した瞬間に、最新のHPや攻撃力の数値を反映させる
        if (isActive && uiController != null)
        {
            uiController.RefreshUI();
        }
    }
}