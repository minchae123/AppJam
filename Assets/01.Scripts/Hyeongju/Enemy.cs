using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform player;

    private protected Rigidbody2D _rigid;
    private protected Vector2 movement;
    private bool playerDie = false;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rigid.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        float distance = (player.transform.position - transform.position).sqrMagnitude;
        if (distance < 20 && !playerDie)
            MoveCharacter(movement);
    }
    private void MoveCharacter(Vector2 direction)
    {
        _rigid.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDie = true;
        }
    }
}
