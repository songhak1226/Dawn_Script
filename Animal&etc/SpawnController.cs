using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{


    RemainTimer remain;

    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] float spawnInterval = 2f;// �� ���� ����
    EnemySpawner[] spawners; //EnemySpawner�� ����Ʈ
    public AudioSource audioSource;
    float timer = 0f; //�����ð� �������� Ÿ�̸� ����

    void Start()
    {
        //�ڽ� ������Ʈ�� �����ϴ� EnemySpawner ����Ʈ�� ���
        spawners = GetComponentsInChildren<EnemySpawner>();
        remain = GetComponent<RemainTimer>();
        remain = FindObjectOfType<RemainTimer>();
        audioSource = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//Ÿ�̸� ����
        //���� ������ ����
        if (spawnInterval < timer)
        {
            //�������� EnemySpawner���� �����ؼ� ���� ������Ų��.
            var index = Random.Range(0, spawners.Length);
            spawners[index].Spawn();

            //timer����
            timer = 0f;
        }

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Arrow")
        {
            audioSource.Play();
            Instantiate(hitParticlePrefab, transform.position, transform.rotation); // �Ѿ� ���� ������ ����
            Invoke("asdf", 0.7f);
        }
    }
    void asdf()
    {
        Destroy(gameObject);    // �ڽ��� ���� ������Ʈ�� ����
    }
}