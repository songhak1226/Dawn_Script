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
        // ȭ�� �����ʿ��� �����̵� �� �Ѵ�.
        // sequence.Append(rectTranform.DOMoveY(0.0f, 1.0f));

        //ȭ�� �������� �����̵� �ƿ� �Ѵ�.
        Invoke("slide",1f); 
    }
    void slide()
    {        // rectTranform ������Ʈ ���
        var rectTranform = GetComponent<RectTransform>();

        //DOTween�� �������� �ۼ�
        var sequence = DOTween.Sequence();
        sequence.Append(rectTranform.DOMoveX(5.0f, 3f));
    }

}
