using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;
    private float yBound = 3.75f;
    private float moveSpeedTouchControl = 0.05f;
    void Update()
    {
        float movement;
        if (isPaddle1)
        {
            // Mobile
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mousePos.x < -0.1)
                {
                    if (mousePos.y > 0.1)
                        transform.Translate(0, moveSpeedTouchControl, 0);
                    else if (mousePos.y < -0.1)
                        transform.Translate(0, -moveSpeedTouchControl, 0);
                }
            }

            // Keyboard
            movement = Input.GetAxisRaw("Vertical2");
        }
        else
        {
            // Mobile
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mousePos.x > 0.1)
                {
                    if (mousePos.y > 0.1)
                        transform.Translate(0, moveSpeedTouchControl, 0);
                    else if (mousePos.y < -0.1)
                        transform.Translate(0, -moveSpeedTouchControl, 0);
                }
            }

            // Keyboard
            movement = Input.GetAxisRaw("Vertical");
        }
        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}
