using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    private Rigidbody2D _body;
    private Animator _animator;
    private BoxCollider2D _box;

    [SerializeField] private float speed = 4.5f;
    [SerializeField] private float jumpForce = 12.0f;
    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
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
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        _animator.SetFloat("Speed", Mathf.Abs(deltaX));

        if (deltaX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (deltaX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
