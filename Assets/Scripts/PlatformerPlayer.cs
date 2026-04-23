using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float speed = 4.5f;
    public float jumpForce = 12.0f;

    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D box;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(max.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null)
        {
            grounded = true;
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

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
