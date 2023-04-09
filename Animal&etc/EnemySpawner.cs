using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] Transform Apostion;
    //[SerializeField] Enemy enemyPrefab; //출연시키는 적의 프리팹 
    [SerializeField] Enemy[] enemyPrefabs;

    Enemy enemy; //출현중인 적을 보유 

    void Start()
    {
      
    }

    public void Spawn()
    {
        
            //등록되어 있는 적의 프리팹에서 하나를 랜덤으로 선택
            var index = Random.Range(0, enemyPrefabs.Length);

            enemy = Instantiate(enemyPrefabs[index], transform.position, transform.rotation); //지정한 위치에 적 생성 
            //enemy = Instantiate(enemyPrefabs[index], Apostion); //Apostion 위치에 생성
        
    }
}
