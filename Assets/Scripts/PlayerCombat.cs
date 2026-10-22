using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 20;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackCooldown = 0.5f;
    private float nextAttackTime;

    private void Update()
    {
        // Kiểm tra nếu người chơi bấm phím Space (phím Cách)
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void Attack()
    {
        // 1. Tạo một vùng quét hình tròn để tìm tất cả các Collider2D thuộc enemyLayer trong phạm vi attackRange
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackPoint.position, 
            attackRange, 
            enemyLayer
        );

        // 2. Duyệt qua từng đối tượng quét được
        foreach (Collider2D hit in hits)
        {
            // Lấy script EnemyHealth từ đối tượng va chạm
            EnemyHealth enemyHealth = hit.GetComponent<EnemyHealth>();

            // Nếu đối tượng đó thực sự có script EnemyHealth (là kẻ địch)
            if (enemyHealth != null)
            {
                // Gây sát thương
                enemyHealth.TakeDamege(attackDamage);
            }
        }
    }
}