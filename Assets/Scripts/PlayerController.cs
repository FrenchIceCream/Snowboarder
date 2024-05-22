using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 1f;
    [SerializeField] float boostSpeed = 1f;
    Rigidbody2D rb;
    SurfaceEffector2D[] surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectsByType<SurfaceEffector2D>(FindObjectsSortMode.None);
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            RotatePlayer();
            BoostPlayer();
        }
    }

    void BoostPlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            foreach (SurfaceEffector2D effector in surfaceEffector2D)
                effector.speed = boostSpeed;
        }
        else 
        {
            foreach (SurfaceEffector2D effector in surfaceEffector2D)
                effector.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-torqueAmount);
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
