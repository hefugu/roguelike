using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnRadius = 12f;
    float gameTime;
    void Start()
    {
        Debug.Log("Spawner start");

        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Debug.Log("Spawn enemy");

        Vector2 pos = Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        spawnInterval = Mathf.Max(0.3f, 2f - gameTime * 0.05f);
    }
}