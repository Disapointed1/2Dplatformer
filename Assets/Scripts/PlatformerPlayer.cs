using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float speed = 4.5f;

    private Rigidbody2D body;
    private Animator animator;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;

        animator.SetFloat("Speed", Mathf.Abs(deltaX));

        if (deltaX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (deltaX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
