using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] Transform Apostion;
    //[SerializeField] Enemy enemyPrefab; //�⿬��Ű�� ���� ������ 
    [SerializeField] Enemy[] enemyPrefabs;

    Enemy enemy; //�������� ���� ���� 

    void Start()
    {
      
    }

    public void Spawn()
    {
        
            //��ϵǾ� �ִ� ���� �����տ��� �ϳ��� �������� ����
            var index = Random.Range(0, enemyPrefabs.Length);

            enemy = Instantiate(enemyPrefabs[index], transform.position, transform.rotation); //������ ��ġ�� �� ���� 
            //enemy = Instantiate(enemyPrefabs[index], Apostion); //Apostion ��ġ�� ����
        
    }
}
