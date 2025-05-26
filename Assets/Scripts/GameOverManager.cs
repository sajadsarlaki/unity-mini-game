using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public GameObject gameOverPanel;
    public Button restartButton;



    
    void Start()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerGameOver()
    {
        Time.timeScale = 0f; // Freeze time
        gameOverPanel.SetActive(true);

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        int activeScene_index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene_index);
    }
}
