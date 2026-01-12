using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public Rigidbody2D rb;

    Vector2 movement;

    void Update()
    {
        // 入力の受付（矢印キーやWASD）
        // GetAxisRawを使うと遊びのないキビキビした動きになります
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // 物理演算を用いた移動処理
        // normalizedで斜め移動が速くなるのを防ぎます
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}