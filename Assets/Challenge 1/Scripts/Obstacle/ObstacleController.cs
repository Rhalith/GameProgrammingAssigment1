using System;
using Scripts.Managers;
using UnityEngine;

namespace Scripts.Obstacle
{
    public class ObstacleController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Game Over");
                GameManager.Instance.GameOver();
            }
        }
    }
}