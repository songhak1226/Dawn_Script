using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    public int i;
    [SerializeField] GameObject Key;
    Text uiText;                            //UIText 컴포넌트
    public int Points { get; private set; } //현재의 점수 포인트
    private void Awake()
    {
        LoadData();
    }
    void Start()
    {
        uiText = GetComponent<Text>();

    }

    public void AddScore(int addPoint)
    {
        //현재의 포인트에 더함
        Points += addPoint;
        //점수 갱신
        uiText.text = string.Format("{0:D3}/250", Points);
    }
    // Update is called once per frame
    void Update()
    {
        SaveData();

        GameObject[] spawnerCount = GameObject.FindGameObjectsWithTag("Spawner");
        i = spawnerCount.Length;
        if (i == 0 && Points >= 250)
        {
            Key.gameObject.SetActive(true);
        }
    }
    void LoadData()
    {
        Points = PlayerPrefs.GetInt("Score");
    }

    void SaveData()
    {
        PlayerPrefs.SetInt("Score", Points);
    }
    public void ResetScore()
    {
        Points = 0;
    }
}
