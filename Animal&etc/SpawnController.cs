using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{


    RemainTimer remain;

    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] float spawnInterval = 2f;// 적 출현 간격
    EnemySpawner[] spawners; //EnemySpawner의 리스트
    public AudioSource audioSource;
    float timer = 0f; //출현시간 판정용의 타이머 변수

    void Start()
    {
        //자식 오브젝트에 존재하는 EnemySpawner 리스트를 취득
        spawners = GetComponentsInChildren<EnemySpawner>();
        remain = GetComponent<RemainTimer>();
        remain = FindObjectOfType<RemainTimer>();
        audioSource = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//타이머 갱신
        //출현 간격의 판정
        if (spawnInterval < timer)
        {
            //랜덤으로 EnemySpawnerㄹ르 선택해서 적을 출현시킨다.
            var index = Random.Range(0, spawners.Length);
            spawners[index].Spawn();

            //timer리셋
            timer = 0f;
        }

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Arrow")
        {
            audioSource.Play();
            Instantiate(hitParticlePrefab, transform.position, transform.rotation); // 총알 적중 지점에 연츨
            Invoke("asdf", 0.7f);
        }
    }
    void asdf()
    {
        Destroy(gameObject);    // 자신의 게임 오브젝트를 제거
    }
}