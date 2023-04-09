using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using System.Collections;
[RequireComponent(typeof(RectTransform))]
public class LionMove : MonoBehaviour
{
    public float Speed = 1;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // 오디오 소스 생성해서 추가
        audioSource = GetComponent<AudioSource>();
        var rectTranform = GetComponent<RectTransform>();
        

        //DOTween의 시퀀스를 작성
        var sequence = DOTween.Sequence();
        sequence.Append(rectTranform.DOMoveY(1.5f, 3f));
    }
    void OnTriggerEnter(Collider other)
    {
     

        if (other.gameObject.tag == "Arrow")
        {

            audioSource.Play();
            Invoke("Move", 0.2f);
        }
    }
    void Move()
    {
        var rectTranform = GetComponent<RectTransform>();

        //DOTween의 시퀀스를 작성
        var sequence1 = DOTween.Sequence();
        sequence1.Append(rectTranform.DOMoveZ(-3.13f, 10f));
        Debug.Log("이동");
    }
    // Update is called once per frame
    void Update()
    {
        //  transform.Translate(Vector3.up * Time.deltaTime);

    }
}


