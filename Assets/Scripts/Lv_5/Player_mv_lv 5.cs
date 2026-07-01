using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player_mv_lv5 : MonoBehaviour
{
    public float speed = 6f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;

    private float moveX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Custom Controls
        if (Input.GetKey(KeyCode.Space))
        {
            moveX = -1f;   // Move Left
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = 1f;    // Move Right
        }
        else
        {
            moveX = 0f;
        }

        // Flip Sprite
        if (moveX != 0)
            sprite.flipX = moveX < 0;

        // Run Animation
        animator.SetBool("isRun", Mathf.Abs(moveX) > 0.1f);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
}