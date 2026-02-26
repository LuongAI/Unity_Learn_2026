using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 120f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float boostMultiplier = 2f;
    float moveAmount;
    float steerAmount;
    bool isBoosted = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Let's control your car");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoostSpeed"))
        {
            isBoosted = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isBoosted = false;
    }

    // Update is called once per frame
    void Update()
    {
        int move = 0;
        int steer = 0;
        bool isBoosting = Keyboard.current.leftShiftKey.isPressed
               || Keyboard.current.rightShiftKey.isPressed;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1;
        }
        float currentMoveSpeed = isBoosting && isBoosted ? moveSpeed * boostMultiplier : moveSpeed;
        moveAmount = move * currentMoveSpeed * Time.deltaTime;
        steerAmount = steer * steerSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);

    }
}
