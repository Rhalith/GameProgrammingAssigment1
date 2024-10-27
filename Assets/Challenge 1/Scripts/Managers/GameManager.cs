using Scripts.Player;
using UnityEngine;

namespace Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerControllerX playerControllerX;
        [SerializeField] private GameObject gameOverScreen;
        
        public void GameOver()
        {
            playerControllerX.StopMovement();
            gameOverScreen.SetActive(true);
        }
    }
}