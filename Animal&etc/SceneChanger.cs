using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

        public void QuitGame()
    {
        Application.Quit();
    }
    public void ReloadScene()
    {
        //현재의 씬을 취득
        var scene = SceneManager.GetActiveScene();

        //현재의 씬을 다시 로드
        SceneManager.LoadScene(scene.name);

       // Debug.Log(scene.name);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
