using UnityEngine;
using UnityEngine.InputSystem;

public class Yusha : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float _speed;

    private Vector2 _inputVelocity;
    private Rigidbody2D _rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputVelocity = Vector2.zero;
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        _rigid.linearVelocity = _inputVelocity * _speed;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _inputVelocity = context.ReadValue<Vector2>();
    }
}
