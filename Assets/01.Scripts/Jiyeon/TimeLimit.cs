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

    bool isStop = false;

    // Update is called once per frame
    void Update()
    {
        //���� ���ϸ� ��� �ð� �帧
        if(isStop != true)
            setTime -= Time.deltaTime;
        min = (int)setTime / 60;
        sec = (int)setTime % 60;
     
        if(sec < 10)  //�ڸ��� ���߱�
            TimeText.text = "���ѽð� " + min + ":0" + sec;
        else
            TimeText.text = "���ѽð� " + min + ":" + sec;

        if(setTime == 0)  //���ѽð� ����
        {

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Flower"))
        {
            FlowerTouch();

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Flower"))
        {
            TimeReStart();
        }
    }


    public void FlowerTouch()  //�ɿ� ���������� �Լ�
    {
        print("����");
        isStop = true;
    }

    public void TimeReStart()
    {
        print("����");
        isStop = false;
    }
}
