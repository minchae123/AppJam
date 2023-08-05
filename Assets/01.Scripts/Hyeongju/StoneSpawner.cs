using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public GameObject Stone;

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            float spawnTime = Random.Range(2.0f, 5.0f);
            yield return new WaitForSeconds(spawnTime);
            Instantiate(Stone);
        }
    }
}
