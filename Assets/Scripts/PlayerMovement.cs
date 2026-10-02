
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private UnityEngine.Vector2 direction;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        UnityEngine.Vector3 movement = new(direction.x, direction.y, 0f);

        //     transform.position += moveSpeed * Time.deltaTime * movement;

        direction = new(horizontal, vertical);
        if (direction.sqrMagnitude > 1f)
        {
            direction.Normalize();
        }
    }

    void FixedUpdate()
    {
        UnityEngine.Vector2 targetPosition =
            rb.position + (moveSpeed * Time.fixedDeltaTime * direction);
        rb.MovePosition(targetPosition);
    }
}
