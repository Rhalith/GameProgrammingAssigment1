using UnityEngine;

namespace Scripts.Obstacle
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionEffect; // Reference to the explosion particle system
        private void Awake()
        {
            if (explosionEffect != null)
            {
                explosionEffect.Stop();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Player")) 
                return;
            // I assigned GameController tag to enemy planes
            Explode(collision.gameObject.CompareTag("GameController")); 
        }

        private void Explode(bool isEnemy)
        {
            if (explosionEffect != null && !isEnemy)
            {
                explosionEffect.transform.parent = null;
                explosionEffect.Play();
            }
            Debug.Log("Bomb Exploded");
            Debug.Log("Is Enemy: " + isEnemy);
            Destroy(gameObject);
            if (explosionEffect != null)
            {
                Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
            }
        }
    }
}