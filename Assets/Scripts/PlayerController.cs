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

        Move(x, y);
    }

    void MoveByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float x = touch.position.x - Camera.main.WorldToScreenPoint(gameObject.transform.position).x;
            float y = touch.position.y - Camera.main.WorldToScreenPoint(gameObject.transform.position).y;

            Move(x, y);
        }
    }

    void Move(float x, float y)
    {
        if (x >= 0.0f && y >= 0.0f)
        {
            spriteRenderer.flipX = false;

            if ((x - y) > -diagonalArea && (x - y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -45.0f);
            }
            else if (x >= y)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
        else if (x >= 0.0f && y < 0.0f)
        {
            spriteRenderer.flipX = false;

            if ((x + y) > -diagonalArea && (x + y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -135.0f);
            }
            else if ((x + y) >= 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -90.0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, -180.0f);
            }
        }
        else if (x < 0.0f && y >= 0.0f)
        {
            spriteRenderer.flipX = true;

            if ((x + y) > -diagonalArea && (x + y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 45.0f);
            }
            else if ((x + y) >= 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            }
        }
        else if (x < 0.0f && y < 0.0f)
        {
            spriteRenderer.flipX = true;

            if ((x - y) > -diagonalArea && (x - y) < diagonalArea)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 135.0f);
            }
            else if (x <= y)
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            }
            else
            {
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
            }
        }

        body.velocity = new Vector2(x, y).normalized * Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
