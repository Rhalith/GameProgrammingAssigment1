using System.Collections;
using Scripts.Plane;
using UnityEngine;

namespace Scripts.Managers
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPlanePrefab; // Enemy plane prefab reference
        [SerializeField] private float spawnInterval = 5f; // Time interval between spawns
        [SerializeField] private Vector2 spawnRangeX = new Vector2(-50f, 50f); // X range for random spawn position
        [SerializeField] private Vector2 spawnRangeY = new Vector2(10f, 30f); // Y range for random spawn height
        [SerializeField] private float minSpeed = 5f; // Minimum speed for enemy planes
        [SerializeField] private float maxSpeed = 20f; // Maximum speed for enemy planes

        private void Start()
        {
            // Start the enemy spawn loop
            StartCoroutine(SpawnEnemyPlanes());
        }

        private IEnumerator SpawnEnemyPlanes()
        {
            while (true)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval); // Wait before spawning the next enemy
            }
        }

        private void SpawnEnemy()
        {
            // Randomize position within specified ranges
            float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
            float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
            Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z);

            // Instantiate the enemy plane
            GameObject enemy = Instantiate(enemyPlanePrefab, spawnPosition, Quaternion.identity);

            // Set a random speed on the EnemyPlane script
            EnemyPlane enemyScript = enemy.GetComponent<EnemyPlane>();
            if (enemyScript != null)
            {
                enemyScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
            }
        }
    }
}