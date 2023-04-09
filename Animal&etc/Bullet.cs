using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    //[SerializeField] ParticleSystem hitParticlePrefab;  // �Ѿ��� ������ ���� ������

    void Start()
    { 
        // Rigidbody ������Ʈ ���
        var rigidbody = GetComponent<Rigidbody>();
    }

    // Ʈ���� ���� ���� �ÿ� ȣ��
    void OnTriggerEnter(Collider other)
    {
        other.SendMessage("OnHitBullet");   // �浹 ��� "OnHitBullet" �޽���
        //Instantiate(hitParticlePrefab, transform.position, transform.rotation); // �Ѿ� ���� ������ ����
        //Destroy(gameObject);    // �ڽ��� ���� ������Ʈ�� ����
    }
}
