using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    //[SerializeField] ParticleSystem hitParticlePrefab;  // 총알이 적중할 때의 프리맵

    void Start()
    { 
        // Rigidbody 컴포넌트 취득
        var rigidbody = GetComponent<Rigidbody>();
    }

    // 트리거 영역 진입 시에 호출
    void OnTriggerEnter(Collider other)
    {
        other.SendMessage("OnHitBullet");   // 충돌 대상에 "OnHitBullet" 메시지
        //Instantiate(hitParticlePrefab, transform.position, transform.rotation); // 총알 적중 지점에 연츨
        //Destroy(gameObject);    // 자신의 게임 오브젝트를 제거
    }
}
