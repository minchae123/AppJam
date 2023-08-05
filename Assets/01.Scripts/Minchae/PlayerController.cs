using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody2D rigid;

    public float rayDis;
    public LayerMask ground;
    public bool isJump;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayDis, ground);
        if (hit)
        {
            print("dd");
            isJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isJump != true)
        {
            isJump = true;
            Jump();
        }
    }

    public void Jump()
    {
        rigid.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
    }
}
