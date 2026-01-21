using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public GameObject enemyPrefab;   // 적 프리팹
    public float spawnInterval = 1.5f; // 생성 간격
    public float spawnY = 5f;          // 화면 상단 Y 위치
    public float minX = -2.5f;         // 왼쪽 경계
    public float maxX = 2.5f;          // 오른쪽 경계

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPos = new Vector2(randomX, spawnY);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
