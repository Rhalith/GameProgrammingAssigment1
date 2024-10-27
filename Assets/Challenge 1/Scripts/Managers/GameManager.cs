using Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerControllerX playerControllerX;
        [SerializeField] private GameObject gameOverScreen;
        
        public static GameManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        public void GameOver()
        {
            playerControllerX.CanMove = false;
            gameOverScreen.SetActive(true);
        }
        
        public void RestartGame()
        {
            // Reload the current active scene to restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}