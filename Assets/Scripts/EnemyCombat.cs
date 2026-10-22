using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackCooldown = 1f;
    private float nextAttackTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Nếu đối tượng đang chạm không phải là Player thì dừng lại ngay
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        // Kiểm tra thời gian hồi chiêu (Cooldown), nếu chưa tới thời gian được đánh tiếp thì dừng lại
        if (Time.time < nextAttackTime)
        {
            return;
        }

        // Lấy component PlayerHealth từ đối tượng Player va chạm
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            // Gây sát thương cho người chơi
            playerHealth.TakeDamage(damage);
            
            // Cập nhật lại mốc thời gian có thể đánh tiếp theo (Thời gian hiện tại + thời gian hồi chiêu)
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}