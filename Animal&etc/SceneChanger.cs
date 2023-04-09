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
        //������ ���� ���
        var scene = SceneManager.GetActiveScene();

        //������ ���� �ٽ� �ε�
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
