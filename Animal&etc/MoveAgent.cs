using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    //Animator anim;
    //[SerializeField] float MoveSpeed;
    NavMeshAgent agent; //내비메시 에이전트
    public Transform transform1;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //내비메시 에이전트를 취득
        agent = GetComponent<NavMeshAgent>();
        //다음 지점으로 이동
        //anim.SetTrigger("WalkT");
        GotoNextPoint();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //목적지 부근에 도착했는지?
        if (agent.remainingDistance < 0.5f)
        {
          
            //다음지점으로 이동
            GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        
        //바닥의 이동 지점을 랜덤으로 작성
        // var nextPoint = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f));
        //var nextPoint =  Vector3.forward * Time.deltaTime;
        //내비메시 에이전트에 목적지를 지정
        agent.SetDestination(transform1.position);
    }

   
}
