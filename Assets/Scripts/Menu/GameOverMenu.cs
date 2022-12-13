using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;

    public PlayerStats playerStats;

    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.isMintaRestart == true)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {        
        gameOverMenu.SetActive(true);
        isGameOver = true;        
    }

    public void GoRestartMenu()
    {        
        gameOverMenu.SetActive(false);
        isGameOver = false;
        //get current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Dashboard");
        isGameOver = false;
    }
}
