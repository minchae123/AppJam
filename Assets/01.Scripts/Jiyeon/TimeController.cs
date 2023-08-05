using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;
    [SerializeField] private TextMeshProUGUI timeTxt;

    public float timer = 300;  //5분
    int min = 0;  //분
    int sec = 0;  //초

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Tiem Error");
        Instance = this;

        ResetTime();
        StartCoroutine(TimeGo());
    }

    private void Update()
    {
        min = (int)timer / 60;
        sec = (int)timer % 60;

        if (sec < 10)  //자릿수 맞추기
            timeTxt.text = "제한시간 " + min + ":0" + sec;
        else
            timeTxt.text = "제한시간 " + min + ":" + sec;
    }

    public void TimeFlow()
    {
        min = (int)timer / 60;
        sec = (int)timer % 60;
    }

    public void ResetTime()
    {
        timer = 300;
        StartCoroutine(TimeGo());
    }

    public void StopTime()
    {
        StopAllCoroutines();
    }

    public IEnumerator ReFlower()
    {
        yield return new WaitForSeconds(10);
        ResetTime();
    }

    IEnumerator TimeGo()
    {
        while(true)
        {
            timer--;
            yield return new WaitForSeconds(1);
        }
    }
}
