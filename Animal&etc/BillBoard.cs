using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    // 지면코드 
    void Update()
    {
        transform.forward = GameObject.Find("Main Camera").GetComponent<Camera>().transform.forward;
    }

    // 지면 관계 상 위와 같이 됐으나 아래 주석 부분의 작성법이 처리가 가볍습니다.
    //Camera mainCamera;
    //void Start()
    //{
    //    //메인 카메라의 취득
    //    mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    //}
}
