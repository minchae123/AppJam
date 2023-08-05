using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public TextMeshProUGUI TimeText;  //제한시간 텍스트
    float setTime = 300;  //5분
    int min = 0;  //분
    int sec = 0;  //초

    bool isStop = false;

    // Update is called once per frame
    void Update()
    {
        //도착 안하면 계속 시간 흐름
        if(isStop != true)
            setTime -= Time.deltaTime;
        min = (int)setTime / 60;
        sec = (int)setTime % 60;
     
        if(sec < 10)  //자릿수 맞추기
            TimeText.text = "제한시간 " + min + ":0" + sec;
        else
            TimeText.text = "제한시간 " + min + ":" + sec;

        if(setTime == 0)  //제한시간 종료
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


    public void FlowerTouch()  //꽃에 도착했을때 함수
    {
        print("멈춤");
        isStop = true;
    }

    public void TimeReStart()
    {
        print("시작");
        isStop = false;
    }
}
