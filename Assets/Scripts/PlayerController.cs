using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
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
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(x * moveSpeed, y * moveSpeed);
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
