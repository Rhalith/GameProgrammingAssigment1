using UnityEngine;

namespace Scripts.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab; // Reference to the bomb prefab
        [SerializeField] private Transform bombSpawnPoint; // Point where bombs will be spawned
        [SerializeField] private float bombLaunchForce = 10f; // Force to launch the bomb downward

        private void Update()
        {
            // Check if the spacebar is pressed to launch a bomb
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBomb();
            }
        }

        private void LaunchBomb()
        {
            // Instantiate a bomb at the specified spawn point with the plane's rotation
            GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);

            // Apply downward force to simulate dropping the bomb
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.down * bombLaunchForce, ForceMode.Impulse);
            }
        }
    }
}