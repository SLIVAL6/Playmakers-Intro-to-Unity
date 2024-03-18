using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public enum SpawnPosition { Left, Right, Top, Bottom }
    [HideInInspector] public SpawnPosition position;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Vector2 leftSpawnPosition = new Vector2(-5f, 0f);
    
    [SerializeField] private Vector2 rightSpawnPosition = new Vector2(5f, 0f);
    
    [SerializeField] private Vector2 topSpawnPosition = new Vector2(0f, 3f);
    
    [SerializeField] private Vector2 bottomSpawnPosition = new Vector2(0f, -3f);
    [SerializeField] private int pickups = 0;
    [HideInInspector] public int Pickups 
    { 
        get { return pickups; } 
        set { pickups = value; }
    }

    private void Awake() 
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        FlipSprite();
        ProcessAnimationSpeed();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x * moveSpeed, y * moveSpeed);
    }

    private void FlipSprite()
    {
        if (spriteRenderer == null)
            return;

        if (rb.velocity.x >= 0.2f)
            spriteRenderer.flipX = false;
        else if (rb.velocity.x <= -0.2f)
            spriteRenderer.flipX = true;
    }

    private void ProcessAnimationSpeed()
    {
        if (animator == null)
            return;
        
        if (rb.velocity == Vector2.zero)
            animator.speed = 0f;
        else
            animator.speed = 1f;
    }

    public void RepositionPlayer(SpawnPosition position)
    {
        switch (position)
        {
            case SpawnPosition.Left:
                transform.position = leftSpawnPosition;
                break;
            case SpawnPosition.Right:
                transform.position = rightSpawnPosition;
                break;
            case SpawnPosition.Top:
                transform.position = topSpawnPosition;
                break;
            case SpawnPosition.Bottom:
                transform.position = bottomSpawnPosition;
                break;
        }
    }
}
