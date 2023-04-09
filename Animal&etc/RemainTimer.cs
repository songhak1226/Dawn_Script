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
        //Text컴포넌트 취득
        UiText = GetComponent<Text>();
        scoreSystem = GetComponent<ScoreSystem>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        //남은 시간을 설정
        currentTime = gameTime;
        bgm1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //남은 시간을 계산 
        currentTime -= Time.deltaTime;

        //0초 이하로는 안 된다.
        if(currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        //if(currentTime <= 5)
        //{
        //    ti.gameObject.SetActive(true);
        //}
        //남은 시간 텍스트 갱신
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

    //카운트 다운을 하고 있는지?
    public bool IsCountingDown()
    {
        //카운터가 0이 아니면 카운트중
        return currentTime > 0.0f;
    }
    public void endGame()
    {
        currentTime = 0;
    }
}
