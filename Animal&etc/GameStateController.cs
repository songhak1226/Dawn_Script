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
    //스테이트 베이스 클래스
    //private void Awake()
    //{
    //    score = GetComponent<Score>();
    //    score = FindObjectOfType<Score>();
    //}
    abstract class BaseState //추상함수 스테이트의 기본이 되는 것
    {
        public GameStateController Controller { get; set; } //controller 생성자

        public enum StateAction //2가지 액션
        {
            STATE_ACTION_WAIT,
            STATE_ACTION_NEXT
        }

        public BaseState(GameStateController c) { Controller = c; }

        public virtual void OnEnter() { }

        public virtual StateAction OnUpdate() { return StateAction.STATE_ACTION_NEXT;}

        public virtual void OnExit() { }
    }

    //게임 시작 표시 스테이트
    class StartState : BaseState
    {
        float timer;

        public StartState(GameStateController c) : base(c) { }

        public override void OnEnter() //start
        {
            //타이머를 표시
            Controller.timer.gameObject.SetActive(true);

            //start 문자열을 표시
            Controller.gameStart.SetActive(true);

            //spawners를 표시
            Controller.spawners.SetActive(true);

        }

        public override StateAction OnUpdate()//1초 후에 다음스테이지로 보낸다
        {
            timer += Time.deltaTime;
            //1초 후에 다음으로
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
    //게임 플레이 스테이트
    class PlayingState : BaseState //Playing 활성화,OnEnter가 없이 바로 실행
    {
        public PlayingState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            //start문자열을 숨김
            Controller.gameStart.SetActive(false); //gameStart를 비활성화

        }
        public override StateAction OnUpdate()
        {
            //타이머가 종료하면 게임 오버로
            if (!Controller.timer.IsCountingDown())
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {

            //적의 발생을 멈춘다
            //Controller.spawners.SetActive(false);

        }
    }
  
    //결과 표시 스테이트 
    class ResultState : BaseState
    {
        public ResultState(GameStateController c) : base(c) { }
        public override void OnEnter()

        {
            Debug.Log("EndTiemr");
            //Controller.EndButton.SetActive(true);
            //SceneManager.LoadScene("HappyEnding");
            ////결과표시
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

    //게임의 상태 리스트
    List<BaseState> state;

    //현재의 게임 상태
    int currentState;

    void Start()
    {
        //게임의 상태를 순서대로 등록
        state = new List<BaseState>
        {
            new StartState(this),
            new PlayingState(this),
            new ResultState(this),
        };

        //처음 상태의 시작 처리
        state[currentState].OnEnter();//********
    }
    void Update()
    {
        //상태를 갱신
        var stateAction = state[currentState].OnUpdate();

        //다음 상태로 전환할지 판정
        if(stateAction == BaseState.StateAction.STATE_ACTION_NEXT)
        {
            //상태 종료 처리
            state[currentState].OnExit();
            //다음의 상태로
            ++currentState;
            //상태 시작 처리
            state[currentState].OnEnter();//********
        }
    }
}
