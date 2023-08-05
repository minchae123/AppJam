using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public GameObject[] Stone;
    float Timer = 0;
    private void Update()
    {
        float spawnTime = Random.Range(2f, 5f);
        int PrefabdjWJrh = Random.Range(0, 2);
        Timer += Time.deltaTime;
        if (Timer > spawnTime)
        {
            Instantiate(Stone[PrefabdjWJrh]);
            Timer = 0;
        }
    }
}