using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerUpper : MonoBehaviour
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
            // Check if arrow keys are pressed
            bool rightArrowPressed = Input.GetKey(KeyCode.RightArrow);
            bool leftArrowPressed = Input.GetKey(KeyCode.LeftArrow);
            bool upArrowPressed = Input.GetKey(KeyCode.UpArrow);
            bool downArrowPressed = Input.GetKey(KeyCode.DownArrow);

            // Calculate movement vector based on arrow key presses
            float horizontalInput = 0f;
            float verticalInput = 0f;

            if (rightArrowPressed)
                horizontalInput += 1f;
            if (leftArrowPressed)
                horizontalInput -= 1f;
            if (upArrowPressed)
                verticalInput += 1f;
            if (downArrowPressed)
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
