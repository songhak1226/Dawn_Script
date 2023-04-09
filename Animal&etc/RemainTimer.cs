using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Text))]
public class RemainTimer : MonoBehaviour
{
    ScoreSystem scoreSystem;
    [SerializeField] float gameTime = 10.0f;
    [SerializeField] GameObject spawner1;
    [SerializeField] GameObject bgm1;
    [SerializeField] GameObject bgm2;
    //[SerializeField] GameObject volume;
    //[SerializeField] GameObject spawner;
    public int vhp = 3;
    Text UiText;
    public float currentTime;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    void Start()
    {
        //Text������Ʈ ���
        UiText = GetComponent<Text>();
        scoreSystem = GetComponent<ScoreSystem>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        //���� �ð��� ����
        currentTime = gameTime;
        bgm1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //���� �ð��� ��� 
        currentTime -= Time.deltaTime;

        //0�� ���Ϸδ� �� �ȴ�.
        if(currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        //if(currentTime <= 5)
        //{
        //    ti.gameObject.SetActive(true);
        //}
        //���� �ð� �ؽ�Ʈ ����
        UiText.text = string.Format("{0}", (int)currentTime);

        if (vhp <= 0)
        {
            LoadScene("BadEnding");
        }

        if ((int)currentTime == 30)
        {
            spawner1.gameObject.SetActive(true);
            bgm1.gameObject.SetActive(false);
            bgm2.gameObject.SetActive(true);
            //volume.gameObject.SetActive(true);
            //spawner.gameObject.SetActive(false);
        }
    }
    public void Downhp()
    {
        vhp--;
        scoreSystem.isDamage = true;
    }

    //ī��Ʈ �ٿ��� �ϰ� �ִ���?
    public bool IsCountingDown()
    {
        //ī���Ͱ� 0�� �ƴϸ� ī��Ʈ��
        return currentTime > 0.0f;
    }
    public void endGame()
    {
        currentTime = 0;
    }
}
