using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class SlodeInOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 화면 오른쪽에서 슬라이드 인 한다.
        // sequence.Append(rectTranform.DOMoveY(0.0f, 1.0f));

        //화면 왼쪽으로 슬라이드 아웃 한다.
        Invoke("slide",1f); 
    }
    void slide()
    {        // rectTranform 컴포넌트 취득
        var rectTranform = GetComponent<RectTransform>();

        //DOTween의 시퀀스를 작성
        var sequence = DOTween.Sequence();
        sequence.Append(rectTranform.DOMoveX(5.0f, 3f));
    }

}
