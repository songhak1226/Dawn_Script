using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float lifetime = 3f;

    void Start()
    {
        // ���� �ð� ��� �Ŀ� ���� ������Ʈ�� �����Ѵ�.
        Destroy(gameObject, lifetime);
    }

}
