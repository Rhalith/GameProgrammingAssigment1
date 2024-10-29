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

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("test");
                Vector3 launchDirection = bombSpawnPoint.forward + Vector3.down * 0.2f;
                rb.AddForce(launchDirection.normalized * bombLaunchForce, ForceMode.Impulse);
            }
        }
    }
}