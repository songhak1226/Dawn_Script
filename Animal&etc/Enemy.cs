using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    Animator anim;
    [SerializeField] Collider enemyCollider;    // �ݶ��̴�
    [SerializeField] Renderer enemyRenderer;    // ������

    [SerializeField] AudioClip spawnClip; //�������� ����� Ŭ��

    [SerializeField] int hp = 1;
    AudioSource audioSource;    //����� ����ϴ� ����� �ҽ�
    RemainTimer timer;
    [SerializeField] int point = 1;//�������� ���� ���� ����Ʈ***********
    Score score;                    //����******************
    Movement3D movement;
    //[SerializeField] GameObject popupTextPrefab;


    void Start()
    {
        anim = GetComponent<Animator>();
        // AudioSource ������Ʈ�� ����� �д�.
        audioSource = GetComponent<AudioSource>();
        timer = GetComponent<RemainTimer>();
        timer = FindObjectOfType<RemainTimer>();
        movement = GetComponent<Movement3D>();
        movement = FindObjectOfType<Movement3D>();

        // ���� ���� �Ҹ��� ���
        audioSource.PlayOneShot(spawnClip);

        // ���� ������Ʈ�� �˻�
        var gameObj = GameObject.FindWithTag("Score");

         // gameObj�� ���ԵǴ� Score ������Ʈ�� ���
         score = gameObj.GetComponent<Score>();
         score = FindObjectOfType<Score>();
         
    }

    private void Update()
    {
        anim.SetTrigger("WalkT");
    }

    void OnHitArrow()
    {
        // ȭ�� ���� ���� �Ҹ��� ���
        Debug.Log("����");
        //�Ѿ� ���߽� ü�� -1
        --hp;

        //ü���� 0�϶� ���
        if (hp <= 0)
        {
            //anim.SetTrigger("IdleT");
            anim.SetTrigger("DieT");
            GoDown();
            //movement.moveSpeed = 0;
        }

    }

    // �������� ���� ó��
    void GoDown()
    {

        //������ ����
        score.AddScore(point);
         //�˾� �ؽ�Ʈ�� �ۼ�
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

    //�˾� �ؽ�Ʈ�� �ۼ�**************
    //void CreatePopupText()
    //{
    //    //�˾� �ؽ�Ʈ�� �ν��Ͻ� �ۼ�
    //    var text = Instantiate(popupTextPrefab, transform.position, Quaternion.identity);

    //    //�˾� �ؽ�Ʈ�� �ؽ�Ʈ ����
    //    text.GetComponent<TextMesh>().text = string.Format("+{0}",point);
    //}
}
