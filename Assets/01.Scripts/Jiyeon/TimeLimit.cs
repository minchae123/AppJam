using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public TextMeshProUGUI TimeText;  //���ѽð� �ؽ�Ʈ
    float setTime = 300;  //5��
    int min = 0;  //��
    int sec = 0;  //��

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FlowerTouch())  //�ɿ� ����
        {

        }
        else  //���� ���ϸ� ��� �ð� �帧
        {
            if(setTime >= 60f)  //���ѽð��� 1�� �̻��̸�
            {
                setTime -= Time.deltaTime;
                min = (int)setTime / 60;
                sec = (int)setTime % 60;
                TimeText.text = "���ѽð� " + min + ":" + sec;
            }
            else  //���ѽð��� 1�� �̸��̸�
            {
                TimeText.text = "���ѽð� " + (int)setTime;
            }
        }
        
    }
    bool FlowerTouch()  //�ɿ� ���������� �Լ�
    {
        return false;
    }
}
