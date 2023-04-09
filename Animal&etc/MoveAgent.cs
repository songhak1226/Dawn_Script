using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    //Animator anim;
    //[SerializeField] float MoveSpeed;
    NavMeshAgent agent; //����޽� ������Ʈ
    public Transform transform1;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //����޽� ������Ʈ�� ���
        agent = GetComponent<NavMeshAgent>();
        //���� �������� �̵�
        //anim.SetTrigger("WalkT");
        GotoNextPoint();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //������ �αٿ� �����ߴ���?
        if (agent.remainingDistance < 0.5f)
        {
          
            //������������ �̵�
            GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        
        //�ٴ��� �̵� ������ �������� �ۼ�
        // var nextPoint = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f));
        //var nextPoint =  Vector3.forward * Time.deltaTime;
        //����޽� ������Ʈ�� �������� ����
        agent.SetDestination(transform1.position);
    }

   
}
