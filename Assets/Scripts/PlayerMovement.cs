using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 direction;

private void Awake()
    {
        // Lấy component Rigidbody2D gắn trên nhân vật
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 1. Đọc nút bấm từ bàn phím (A, D, W, S hoặc các phím mũi tên)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 2. Gom hướng di chuyển thành một vector 2 chiều (X, Y)
        direction = new Vector2(horizontal, vertical);

        // 3. Chuẩn hóa hướng để khi đi chéo không bị nhanh hơn đi thẳng
        if (direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }
    }

    private void FixedUpdate()
    {
        // 4. Tính toán vị trí mới và di chuyển nhân vật bằng vật lý (Rigidbody2D)
        Vector2 targetPosition = rb.position + (moveSpeed * Time.fixedDeltaTime * direction);
        rb.MovePosition(targetPosition);
    }
    void OCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("You hit: " + collision.gameObject.name + "!");
    }
    void OggerEnter2D(Collider2D Trigger)
    {
        Debug.Log("You received a" + Trigger.gameObject.name + "!");
    }
}