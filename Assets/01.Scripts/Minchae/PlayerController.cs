using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody2D rigid;
    private Collider2D _collider2D;

    public float rayDis;
    public LayerMask ground;

    public Animator enemyAnimator;
    public BackgroundMove backMove;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _collider2D.IsTouchingLayers(ground))
            Jump();
    }

    public void Jump()
    {
        rigid.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
    }

    public void GameOver()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Hurt");
        enemyAnimator.SetTrigger("Over");
        backMove.enabled = false;

        //Destroy(GetComponent<Animator>());
    }
}
