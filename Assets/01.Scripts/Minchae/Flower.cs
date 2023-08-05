using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            TouchFlower();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            ExitFlower();
        }
    }

    public void ExitFlower()
    {
        print(2);
        TimeController.Instance.StartCoroutine(TimeController.Instance.ReFlower());
    }

    public void TouchFlower()
    {
        print(1);
        TimeController.Instance.StopTime();
    }
}
