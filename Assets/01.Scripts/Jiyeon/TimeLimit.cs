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
            setTime -= Time.deltaTime;
            min = (int)setTime / 60;
            sec = (int)setTime % 60;

            if(sec < 10)  //�ڸ��� ���߱�
                TimeText.text = "���ѽð� " + min + ":0" + sec;
            else
                TimeText.text = "���ѽð� " + min + ":" + sec;
        }

        if(setTime == 0)  //���ѽð� ����
        {

        }
        
    }
    bool FlowerTouch()  //�ɿ� ���������� �Լ�
    {

        return false;
    }
}
