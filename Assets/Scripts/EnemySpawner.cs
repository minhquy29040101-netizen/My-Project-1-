using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Kéo thả Prefab của con quái vào đây trong Unity Inspector
    [SerializeField] private GameObject enemyPrefab;
    
    // Tọa độ hoặc vị trí để sinh quái
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        // Gọi hàm sinh quái khi game bắt đầu (hoặc bạn có thể viết hàm riêng để gọi sau)
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Sinh ra con quái tại vị trí của Spawner hoặc điểm spawnPoint
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}