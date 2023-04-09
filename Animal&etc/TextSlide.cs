using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class TextSlide : MonoBehaviour
{   // Start is called before the first frame update
    void Start()
    {
        // rectTranform ������Ʈ ���
        var rectTranform = GetComponent<RectTransform>();

        //DOTween�� �������� �ۼ�
        var sequence = DOTween.Sequence();

        // ȭ�� �����ʿ��� �����̵� �� �Ѵ�.
        // sequence.Append(rectTranform.DOMoveY(0.0f, 1.0f));

        //ȭ�� �������� �����̵� �ƿ� �Ѵ�.
        sequence.Append(rectTranform.DOMoveY(-1f, 3f));
    }

}