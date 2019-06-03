using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float moveSpeed;
    public float escapeDistance;
    public int turnTime;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private GameObject player;

    private float turnTimeCount = 0;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < escapeDistance)
        {
            Escape();
        }
        else
        {
            Move();
            CheckIfNeededTurn();
        }
    }

    void Move()
    {
        Vector2 direction;

        if (spriteRenderer.flipX)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.right;
        }

        body.velocity = direction * moveSpeed;
    }

    void CheckIfNeededTurn()
    {
        if (turnTimeCount >= turnTime)
        {
            turnTimeCount = 0;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        turnTimeCount += Time.deltaTime;
    }

    void Escape()
    {
        Vector2 direction;

        if (player.transform.position.x >= transform.position.x)
        {
            spriteRenderer.flipX = true;
            direction = Vector2.left;
        }
        else
        {
            spriteRenderer.flipX = false;
            direction = Vector2.right;
        }

        body.velocity = direction * moveSpeed;
    }
}
