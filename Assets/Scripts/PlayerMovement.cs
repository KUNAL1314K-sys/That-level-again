using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
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
        // 🎮 SIMPLE INPUT (WORKS 100%)
        moveX = Input.GetAxisRaw("Horizontal");

        // Flip
        if (moveX != 0)
            sprite.flipX = moveX < 0;

        // Animation
        animator.SetBool("isRun", Mathf.Abs(moveX) > 0.1f);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }
}