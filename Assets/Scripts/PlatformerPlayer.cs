using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    [SerializeField] private  float speed = 4.5f;
    [SerializeField] private float jumpForce = 12.0f;

    private const string AnimatorSpeed = "Speed";
    private const string JumpValue = "Jump";
    private const string HorizontalValue = "Horizontal";

    private Rigidbody2D _body;
    private Animator _animator;
    private BoxCollider2D _box;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _box = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer =  GetComponent<SpriteRenderer>() ;
    }

    // Update is called once per frame
   private void Update()
    {
        float deltaX = Input.GetAxis(HorizontalValue) * speed;
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

        if (grounded && Input.GetButtonDown(JumpValue))
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        _animator.SetFloat(AnimatorSpeed, Mathf.Abs(deltaX));

        if (deltaX > 0)
        {
            _spriteRenderer.flipX = false;
        } else if (deltaX < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
