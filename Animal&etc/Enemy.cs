using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    Animator anim;
    [SerializeField] Collider enemyCollider;    // 콜라이더
    [SerializeField] Renderer enemyRenderer;    // 랜더러

    [SerializeField] AudioClip spawnClip; //출현시의 오디오 클립

    [SerializeField] int hp = 1;
    AudioSource audioSource;    //재생에 사용하는 오디오 소스
    RemainTimer timer;
    [SerializeField] int point = 1;//쓰러졌을 때의 점수 포인트***********
    Score score;                    //점수******************
    Movement3D movement;
    //[SerializeField] GameObject popupTextPrefab;


    void Start()
    {
        anim = GetComponent<Animator>();
        // AudioSource 컴포넌트를 취득해 둔다.
        audioSource = GetComponent<AudioSource>();
        timer = GetComponent<RemainTimer>();
        timer = FindObjectOfType<RemainTimer>();
        movement = GetComponent<Movement3D>();
        movement = FindObjectOfType<Movement3D>();

        // 출현 시의 소리를 재생
        audioSource.PlayOneShot(spawnClip);

        // 게임 오브젝트를 검색
        var gameObj = GameObject.FindWithTag("Score");

         // gameObj에 포함되는 Score 컴포넌트를 취득
         score = gameObj.GetComponent<Score>();
         score = FindObjectOfType<Score>();
         
    }

    private void Update()
    {
        anim.SetTrigger("WalkT");
    }

    void OnHitArrow()
    {
        // 화살 명중 시의 소리를 재생
        Debug.Log("온힛");
        //총알 명중시 체력 -1
        --hp;

        //체력이 0일때 사망
        if (hp <= 0)
        {
            //anim.SetTrigger("IdleT");
            anim.SetTrigger("DieT");
            GoDown();
            //movement.moveSpeed = 0;
        }

    }

    // 쓰러졌을 때의 처리
    void GoDown()
    {

        //점수를 더함
        score.AddScore(point);
         //팝업 텍스트의 작성
         //CreatePopupText();****************
         enemyCollider.enabled = false;
        enemyRenderer.enabled = false;
        
        Destroy(gameObject,0.1f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            timer.Downhp();
            Destroy(gameObject);
        }
    }

    //팝업 텍스트의 작성**************
    //void CreatePopupText()
    //{
    //    //팝업 텍스트의 인스턴스 작성
    //    var text = Instantiate(popupTextPrefab, transform.position, Quaternion.identity);

    //    //팝업 텍스트의 텍스트 변경
    //    text.GetComponent<TextMesh>().text = string.Format("+{0}",point);
    //}
}
