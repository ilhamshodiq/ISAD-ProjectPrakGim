using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToAbout(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void MoveToStage1(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void MoveToStage2(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void MoveToStage3(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void PlayStage1(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void PlayStage2(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void PlayStage3(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Quit!!!");
    }
}
