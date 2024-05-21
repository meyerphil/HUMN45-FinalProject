using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DayCycle DayCycle;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DayCycle = GameObject.Find("DayCycle").GetComponent<DayCycle>();
    }

    void Update()
    {

        if(DayCycle.TimeRunning()){
            bool wPressed = Input.GetKey(KeyCode.W);
            bool aPressed = Input.GetKey(KeyCode.A);
            bool sPressed = Input.GetKey(KeyCode.S);
            bool dPressed = Input.GetKey(KeyCode.D);

            float horizontalInput = 0f;
            float verticalInput = 0f;

            if (dPressed)
                horizontalInput += 1f;
            if (aPressed)
                horizontalInput -= 1f;
            if (wPressed)
                verticalInput += 1f;
            if (sPressed)
                verticalInput -= 1f;

            // Normalize movement vector
            Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

            // Move the player
            rb.velocity = moveDirection * moveSpeed;

        } else {
            // Normalize movement vector
            Vector2 moveDirection = new Vector2(0, 0);

            // Move the player
            rb.velocity = moveDirection * moveSpeed;
        }
    }
}
