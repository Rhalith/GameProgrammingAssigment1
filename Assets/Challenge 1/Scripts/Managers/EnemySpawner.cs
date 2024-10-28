using System.Collections;
using Scripts.Plane;
using UnityEngine;

namespace Scripts.Managers
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPlanePrefab;
        [SerializeField] private float spawnInterval = 5f;
        [SerializeField] private Vector2 spawnRangeX = new Vector2(-50f, 50f);
        [SerializeField] private Vector2 spawnRangeY = new Vector2(10f, 30f);
        [SerializeField] private float minSpeed = 5f;
        [SerializeField] private float maxSpeed = 20f;

        private void Start()
        {
            StartCoroutine(SpawnEnemyPlanes());
        }

        private IEnumerator SpawnEnemyPlanes()
        {
            while (true)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private void SpawnEnemy()
        {
            // Randomize position within specified ranges
            float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
            float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
            Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z);
            
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