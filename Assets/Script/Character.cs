using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    [Header("アニメーション速度")]
    public float walkAnimationSpeed = 10f;

    [Header("横向き (A/D)")]
    public Sprite side1;
    public Sprite side2;

    [Header("上向き (W)")]
    public Sprite up1;
    public Sprite up2;

    [Header("下向き (S)")]
    public Sprite down1;
    public Sprite down2;

    [Header("待機 (正面)")]
    public Sprite idle1;
    public Sprite idle2;

    Vector2 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // アニメーションのコマ（0か1）を計算
        int index = (int)(Time.time * walkAnimationSpeed) % 2;

        if (movement.x != 0)
        {
            // --- 横移動 ---
            sr.sprite = (index == 0) ? side1 : side2;
            sr.flipX = (movement.x > 0); // 左なら反転
        }
        else if (movement.y > 0)
        {
            // --- 上移動 (W) ---
            sr.sprite = (index == 0) ? up1 : up2;
            sr.flipX = false;
        }
        else if (movement.y < 0)
        {
            // --- 下移動 (S) ---
            sr.sprite = (index == 0) ? down1 : down2;
            sr.flipX = false;
        }
        else
        {
            // --- 待機 ---
            // 待機中も少し動かしたい場合は idle アニメーションを再生
            int idleIndex = (int)(Time.time * 2f) % 2; // 待機はゆっくり
            sr.sprite = (idleIndex == 0) ? idle1 : idle2;
            sr.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}