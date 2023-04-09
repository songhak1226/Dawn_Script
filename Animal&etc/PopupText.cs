using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(TextMesh))]
public class PopupText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TextMesh �� ���
        var textMesh = GetComponent<TextMesh>();
        //DOTween�� �������� �ۼ�
        var sequence = DOTween.Sequence();
        //ó���� Ȯ�� ǥ���Ѵ�.
        sequence.Append(transform.DOScale(0.3f, 0.2f));
        //������ ���� �̵���Ų��
        sequence.Append(transform.DOMoveY(3.0f, 0.3f).SetRelative());
        //������ ���� ���
        var color = textMesh.color;
        //���� ���� 0���� �����ؼ� ���ڸ� �������� �Ѵ�.
        color.a = 0.0f; 

        //���� �̵��԰� ���ÿ� �������ϰ� ������� �Ѵ�.
        sequence.Join(DOTween.To(() => textMesh.color, c => textMesh.color = c, color, 0.3f).SetEase(Ease.InOutQuart));
        //��� �ִϸ��̼��� ������ ������ �����Ѵ�
        sequence.OnComplete(() => Destroy(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
