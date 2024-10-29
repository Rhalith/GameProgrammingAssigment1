using UnityEngine;

namespace Scripts.Obstacle
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionEffect;
        private void Awake()
        {
            if (explosionEffect != null)
            {
                explosionEffect.Stop();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Ensure that the bomb does not explode when it collides with the player
            // I did this because if player launch bomb while tilting the plane, the bomb will explode immediately
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
            
            Destroy(gameObject);
            if (explosionEffect != null)
            {
                Destroy(explosionEffect.gameObject, explosionEffect.main.duration);
            }
        }
    }
}