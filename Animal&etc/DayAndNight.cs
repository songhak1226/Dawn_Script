using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNight : MonoBehaviour
{
    [SerializeField] private float secondPerRealTimeSecond; // ���� ���迡���� 100�� = ���� ������ 1��

    private bool isNight = false;

    [SerializeField] private float nightFogDensity; // �� ������ Fog �е�
    private float dayFogDensity; // �� ������ Fog �е�
    [SerializeField] private float fogDensityCalc; // ������ ����
    private float currentFogDensity;
    RemainTimer remaintimer;
    void Start()
    {
        remaintimer = GetComponent<RemainTimer>();
        remaintimer = FindObjectOfType<RemainTimer>();
        dayFogDensity = RenderSettings.fogDensity;
    }

    void Update()
    {
        if(remaintimer.currentTime <= 30)
        {
            RenderSettings.ambientLight = new Color(255/255f,80/255f,45/255f);
        }
        // ��� �¾��� X �� �߽����� ȸ��. ���ǽð� 1�ʿ�  0.1f * secondPerRealTimeSecond ������ŭ ȸ��
        transform.Rotate(Vector3.right, 0.1f * secondPerRealTimeSecond * Time.deltaTime);

        if (transform.eulerAngles.x >= 170) // x �� ȸ���� 170 �̻��̸� ���̶�� �ϰ���
            isNight = true;
        else if (transform.eulerAngles.x <= 10)  // x �� ȸ���� 10 ���ϸ� ���̶�� �ϰ���
            isNight = false;

        if (isNight)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
                RenderSettings.skybox.SetFloat("_Exposure", 0.3f);
            }
        }
        else
        {
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
                RenderSettings.skybox.SetFloat("_Exposure", 1);
            }
        }
    }
    
}
