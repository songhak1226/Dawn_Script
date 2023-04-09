using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStateController : MonoBehaviour
{
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    ResultScore resultScore;
    [SerializeField] RemainTimer timer;
    [SerializeField] GameObject gameStart;
    [SerializeField] GameObject result;
    [SerializeField] GameObject spawners;
    [SerializeField] GameObject rtimer;
    [SerializeField] GameObject ray;
    //[SerializeField] GameObject EndButton;
    //Score score;
    //������Ʈ ���̽� Ŭ����
    //private void Awake()
    //{
    //    score = GetComponent<Score>();
    //    score = FindObjectOfType<Score>();
    //}
    abstract class BaseState //�߻��Լ� ������Ʈ�� �⺻�� �Ǵ� ��
    {
        public GameStateController Controller { get; set; } //controller ������

        public enum StateAction //2���� �׼�
        {
            STATE_ACTION_WAIT,
            STATE_ACTION_NEXT
        }

        public BaseState(GameStateController c) { Controller = c; }

        public virtual void OnEnter() { }

        public virtual StateAction OnUpdate() { return StateAction.STATE_ACTION_NEXT;}

        public virtual void OnExit() { }
    }

    //���� ���� ǥ�� ������Ʈ
    class StartState : BaseState
    {
        float timer;

        public StartState(GameStateController c) : base(c) { }

        public override void OnEnter() //start
        {
            //Ÿ�̸Ӹ� ǥ��
            Controller.timer.gameObject.SetActive(true);

            //start ���ڿ��� ǥ��
            Controller.gameStart.SetActive(true);

            //spawners�� ǥ��
            Controller.spawners.SetActive(true);

        }

        public override StateAction OnUpdate()//1�� �Ŀ� �������������� ������
        {
            timer += Time.deltaTime;
            //1�� �Ŀ� ��������
            if (timer > 2.0f)
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {

        }

    }
    //���� �÷��� ������Ʈ
    class PlayingState : BaseState //Playing Ȱ��ȭ,OnEnter�� ���� �ٷ� ����
    {
        public PlayingState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            //start���ڿ��� ����
            Controller.gameStart.SetActive(false); //gameStart�� ��Ȱ��ȭ

        }
        public override StateAction OnUpdate()
        {
            //Ÿ�̸Ӱ� �����ϸ� ���� ������
            if (!Controller.timer.IsCountingDown())
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {

            //���� �߻��� �����
            //Controller.spawners.SetActive(false);

        }
    }
  
    //��� ǥ�� ������Ʈ 
    class ResultState : BaseState
    {
        public ResultState(GameStateController c) : base(c) { }
        public override void OnEnter()

        {
            Debug.Log("EndTiemr");
            //Controller.EndButton.SetActive(true);
            //SceneManager.LoadScene("HappyEnding");
            ////���ǥ��
            //Controller.ray.SetActive(true);
            //Controller.result.SetActive(true);
            //Controller.rtimer.SetActive(false);
            //GameObject[] objects = GameObject.FindGameObjectsWithTag("EnemyD");
            //for (int i = 0; i < objects.Length; i++)
            //    Destroy(objects[i]);
        }
        public override StateAction OnUpdate()
        {
            return StateAction.STATE_ACTION_WAIT;
        }

       
    }

    //������ ���� ����Ʈ
    List<BaseState> state;

    //������ ���� ����
    int currentState;

    void Start()
    {
        //������ ���¸� ������� ���
        state = new List<BaseState>
        {
            new StartState(this),
            new PlayingState(this),
            new ResultState(this),
        };

        //ó�� ������ ���� ó��
        state[currentState].OnEnter();//********
    }
    void Update()
    {
        //���¸� ����
        var stateAction = state[currentState].OnUpdate();

        //���� ���·� ��ȯ���� ����
        if(stateAction == BaseState.StateAction.STATE_ACTION_NEXT)
        {
            //���� ���� ó��
            state[currentState].OnExit();
            //������ ���·�
            ++currentState;
            //���� ���� ó��
            state[currentState].OnEnter();//********
        }
    }
}
