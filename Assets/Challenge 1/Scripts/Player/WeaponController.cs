using UnityEngine;

namespace Scripts.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab; // Reference to the bomb prefab
        [SerializeField] private Transform bombSpawnPoint; // Point where bombs will be spawned
        [SerializeField] private float bombLaunchForce = 500f; // Launch force for the bomb

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
            // Instantiate a bomb at the spawn point with the plane's rotation
            GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombSpawnPoint.rotation);

            // Apply forward and slightly downward force to launch the bomb
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("test");
                Vector3 launchDirection = bombSpawnPoint.forward + Vector3.down * 0.2f; // Forward with a slight downward angle
                rb.AddForce(launchDirection.normalized * bombLaunchForce, ForceMode.Impulse);
            }
        }
    }
}