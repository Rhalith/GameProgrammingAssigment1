using UnityEngine;

namespace Scripts.Player
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab;
        [SerializeField] private Transform bombSpawnPoint;
        [SerializeField] private float bombLaunchForce = 500f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBomb();
            }
        }

        private void LaunchBomb()
        {
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