using Unity.Netcode;
using UnityEngine;


public class PlayerController : NetworkBehaviour
{
    Rigidbody2D rb;
    float moveHorizontal = 0, moveVertical = 0;
    float moveSpeed = 10;
    Vector2 movement = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;
        Move();
    }

    void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, moveVertical).normalized;
        rb.linearVelocity = movement * moveSpeed;
    }
}
