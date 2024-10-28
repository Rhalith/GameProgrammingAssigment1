using System;
using UnityEngine;

namespace Scripts.Plane
{
    public class EnemyPlane : MonoBehaviour
    {
        private float speed;
        
        [SerializeField] private ParticleSystem explosionEffect;

        private void Awake()
        {
            if (explosionEffect != null)
            {
                explosionEffect.Stop();
            }
        }

        private void Update()
        {
            // Move the enemy plane forward continuously
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }

        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        { 
            Explode(); 
        }

        private void Explode()
        {
            // Play explosion effect and destroy the enemy plane
            if (explosionEffect != null)
            {
                ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration); // Destroy the particle system after playing
            }

            Destroy(gameObject); // Destroy the enemy plane
        }
    }
}