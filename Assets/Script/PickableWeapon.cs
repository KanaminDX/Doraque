using UnityEngine;

public class PickableWeapon : MonoBehaviour
{
    [Header("装備させる武器データ")]
    public Weapon weaponData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーが触れたか判定
        if (other.CompareTag("Player"))
        {
            PlayerStatus status = other.GetComponent<PlayerStatus>();
            if (status != null && weaponData != null)
            {
                // 装備処理を呼び出す
                status.EquipWeapon(weaponData);

                // 拾った演出として消去（あるいはSEを鳴らす）
                Destroy(gameObject);
            }
        }
    }
}