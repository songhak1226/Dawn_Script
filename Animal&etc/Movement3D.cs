using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement3D : MonoBehaviour
{
    
    public float moveSpeed;
    NavMeshAgent navMeshAgent;
    RemainTimer remaintimer;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        remaintimer = GetComponent<RemainTimer>();
        remaintimer = FindObjectOfType<RemainTimer>();
    }
    private void Update()
    {
        if(remaintimer.currentTime <= 30)
        {
            //이동속도 조절 
            //moveSpeed = 5.0f;
        }
    }
    //활 맞으면 이동 중지   
    //void OnHitBullet()
    //{
    //    moveSpeed = 0f;
    //}

    public void MoveTo(Vector3 goalPostion)
    {
        //기존에 이동 행동을 하고 있으면 코루틴 중지
        StopCoroutine(OnMove());

        navMeshAgent.speed = moveSpeed;
        //목표 지점 설정
        navMeshAgent.SetDestination(goalPostion);
        //이동 행동에 대한 코루틴 시작
        StartCoroutine(OnMove());
    }

    IEnumerator OnMove()
    {
        while (true)
        {
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                transform.position = navMeshAgent.destination;
                //현재 설정되어 있는 이동 경로를 초기화 하여 이동을 멈추게 한다
                navMeshAgent.ResetPath();

                break;
            }
            yield return null;
        }
    }


}
