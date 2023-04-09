using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        //������ ���� �ε��Ѵ�
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        //���ø����̼� ����
        Application.Quit();
    }

    public void ReloadScene()
    {
        //������ ���� ���
        var scene = SceneManager.GetActiveScene();

        //������ ���� �ٽ� �ε��Ѵ�
        SceneManager.LoadScene(scene.name);
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
}
