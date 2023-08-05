using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Rigidbody2D _rigid;
    public float speedMin;
    public float speedMax;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float randomValue = Random.Range(speedMin, speedMax);
        _rigid.velocity = Vector3.left * Time.deltaTime * randomValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            FindObjectOfType<StoneSpawner>().StopSpawn();
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}
