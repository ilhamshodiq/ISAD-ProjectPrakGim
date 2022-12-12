using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{
    public GameObject finishMenu;
    public bool isFinish = false;
    // Start is called before the first frame update
    void Start()
    {
        finishMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishMenu.SetActive(true);
            Time.timeScale = 0f;
            isFinish = true;
            Debug.Log("trigger finish");
        }
    }


      public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Dashboard");
        isFinish = false;
    }
}
