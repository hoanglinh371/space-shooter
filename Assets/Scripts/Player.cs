using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingX = 0.5f;
    [SerializeField] float paddingY = 2f;
    Shooter shooter;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    void Awake()
    {
        shooter = FindObjectOfType<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }


    void Update()
    {
        Move();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        shooter.isFiring = value.isPressed;
    }

    void Move()
    {
        Vector3 delta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPosition = new()
        {
            x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingX, maxBounds.x - paddingX),
            y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingY, maxBounds.y - paddingY)
        };
        transform.position = newPosition;
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
}
