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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FlowerTouch())  //꽃에 도착
        {

        }
        else  //도착 안하면 계속 시간 흐름
        {
            if(setTime >= 60f)  //제한시간이 1분 이상이면
            {
                setTime -= Time.deltaTime;
                min = (int)setTime / 60;
                sec = (int)setTime % 60;
                TimeText.text = "제한시간 " + min + ":" + sec;
            }
            else  //제한시간이 1분 미만이면
            {
                TimeText.text = "제한시간 " + (int)setTime;
            }
        }
        
    }
    bool FlowerTouch()  //꽃에 도착했을때 함수
    {
        return false;
    }
}
