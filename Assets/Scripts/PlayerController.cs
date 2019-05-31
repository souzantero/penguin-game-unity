using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private float diagonalArea = 25.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isStarted) return;

        switch (SystemInfo.deviceType)
        {
            case DeviceType.Desktop: MoveByPointer(); break;
            case DeviceType.Handheld: MoveByTouch(); break;
            default: break;
        }
    }

    void MoveByPointer()
    {
        float x = Input.mousePosition.x - Camera.main.WorldToScreenPoint(gameObject.transform.position).x;
        float y = Input.mousePosition.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y;

        TryMove(x, y);
    }

    void MoveByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float x = touch.position.x - Camera.main.WorldToScreenPoint(gameObject.transform.position).x;
            float y = touch.position.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y;

            TryMove(x, y);
        }
    }

    void TryMove(float x, float y)
    {
        if (!CheckBorder(x, y))
        {
            Move(x, y);
        }
    }

    bool CheckBorder(float x, float y)
    {
        if (y > 0.0f && transform.position.y >= 0.25f)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            body.velocity = Vector2.zero;
            return true;
        }
        else if (y < 0.0f && transform.position.y <= -100.0f)
        {
            body.velocity = Vector2.zero;
            return true;
        }
        else if (x > 0.0f && transform.position.x >= 100.0f)
        {
            body.velocity = Vector2.zero;
            return true;
        }
        else if (x < 0.0f && transform.position.x <= -100.0f)
        {
            body.velocity = Vector2.zero;
            return true;
        }

        return false;
    }

    void Move(float x, float y)
    {
        Vector2 direction = Vector2.zero;

        if (x >= 0.0f && y >= 0.0f)
        {
            spriteRenderer.flipX = false;

            if ((x - y) > -diagonalArea && (x - y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -45.0f);
                direction = new Vector2(1, 1).normalized;
            }
            else if (x >= y)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
                direction = Vector2.right;
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                direction = Vector2.up;
            }
        }
        else if (x >= 0.0f && y < 0.0f)
        {
            spriteRenderer.flipX = false;

            if ((x + y) > -diagonalArea && (x + y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -135.0f);
                direction = new Vector2(1, -1).normalized;
            }
            else if ((x + y) >= 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
                direction = Vector2.right;
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -180.0f);
                direction = Vector2.down;
            }
        }
        else if (x < 0.0f && y >= 0.0f)
        {
            spriteRenderer.flipX = true;

            if ((x + y) > -diagonalArea && (x + y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 45.0f);
                direction = new Vector2(-1, 1).normalized;
            }
            else if ((x + y) >= 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                direction = Vector2.up;
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                direction = Vector2.left;
            }
        }
        else if (x < 0.0f && y < 0.0f)
        {
            spriteRenderer.flipX = true;

            if ((x - y) > -diagonalArea && (x - y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 135.0f);
                direction = new Vector2(-1, -1).normalized;
            }
            else if (x <= y)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                direction = Vector2.left;
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                direction = Vector2.down;
            }
        }

        body.velocity = direction * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
