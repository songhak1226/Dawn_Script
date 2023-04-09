using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float lifetime = 3f;

    void Start()
    {
        // 일정 시간 경과 후에 게임 오브젝트를 제거한다.
        Destroy(gameObject, lifetime);
    }

}
