using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    // �����ڵ� 
    void Update()
    {
        transform.forward = GameObject.Find("Main Camera").GetComponent<Camera>().transform.forward;
    }

    // ���� ���� �� ���� ���� ������ �Ʒ� �ּ� �κ��� �ۼ����� ó���� �������ϴ�.
    //Camera mainCamera;
    //void Start()
    //{
    //    //���� ī�޶��� ���
    //    mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    //}
}
