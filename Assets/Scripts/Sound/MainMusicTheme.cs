using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMusicTheme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Stage 1")
        {
            Destroy(gameObject);
            // MainMusicTheme.bgMusic.GetComponent<AudioSource>().Pause();
        }
        
        if (SceneManager.GetActiveScene().name == "Stage 2")
        {
            Destroy(gameObject);
            // MainMusicTheme.bgMusic.GetComponent<AudioSource>().Pause();
        }

        if (SceneManager.GetActiveScene().name == "Stage 3")
        {
            Destroy(gameObject);
            // MainMusicTheme.bgMusic.GetComponent<AudioSource>().Pause();
        }
    }

    // Play music when scene changes
    private static MainMusicTheme bgMusic;


    private void Awake()
    {
        if(bgMusic == null)
        {
            bgMusic = this;
            DontDestroyOnLoad(bgMusic);
        }

        else 
        {
            Destroy(gameObject);
        }
    }

}
