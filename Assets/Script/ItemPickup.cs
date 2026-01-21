using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Weapon weaponData; // のデータをセット
    private bool isPlayerNearby = false;
    private PlayerStatus targetPlayerStatus;

    void Update()
    {
        // プレイヤーが近くにいて、かつ Eキー（または任意のボタン）が押されたら
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    void PickUp()
    {
        if (targetPlayerStatus != null && weaponData != null)
        {
            // PlayerStatusに用意した装備関数を呼ぶ
            targetPlayerStatus.EquipWeapon(weaponData);

            Debug.Log($"{weaponData.Name} を手に入れた！");

            // 剣を画面から消す
            Destroy(gameObject);
        }
    }

    // プレイヤーが範囲内に入った
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            targetPlayerStatus = other.GetComponent<PlayerStatus>();
            Debug.Log("Eキーで拾う");
        }
    }

    // プレイヤーが範囲から出た
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            targetPlayerStatus = null;
        }
    }
}