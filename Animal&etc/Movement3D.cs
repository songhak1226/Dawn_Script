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
            //�̵��ӵ� ���� 
            //moveSpeed = 5.0f;
        }
    }
    //Ȱ ������ �̵� ����   
    //void OnHitBullet()
    //{
    //    moveSpeed = 0f;
    //}

    public void MoveTo(Vector3 goalPostion)
    {
        //������ �̵� �ൿ�� �ϰ� ������ �ڷ�ƾ ����
        StopCoroutine(OnMove());

        navMeshAgent.speed = moveSpeed;
        //��ǥ ���� ����
        navMeshAgent.SetDestination(goalPostion);
        //�̵� �ൿ�� ���� �ڷ�ƾ ����
        StartCoroutine(OnMove());
    }

    IEnumerator OnMove()
    {
        while (true)
        {
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                transform.position = navMeshAgent.destination;
                //���� �����Ǿ� �ִ� �̵� ��θ� �ʱ�ȭ �Ͽ� �̵��� ���߰� �Ѵ�
                navMeshAgent.ResetPath();

                break;
            }
            yield return null;
        }
    }


}
