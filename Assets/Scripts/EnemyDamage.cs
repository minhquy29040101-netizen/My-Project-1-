using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có Tag là "Player" hay không
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lấy script PlayerHealth từ đối tượng va chạm
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Nếu đối tượng đó có script PlayerHealth
            if (playerHealth != null)
            {
                // Gây sát thương cho người chơi
                playerHealth.TakeDamage(damage);
            }
        }
    }
}