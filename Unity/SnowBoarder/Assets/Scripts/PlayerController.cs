using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;

    private void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            ResponseToBoost();
        }
    }

    public void DisableControl()
    {
        canMove = false;
    }

    private void ResponseToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rd2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rd2d.AddTorque(-torqueAmount);
        }
    }
}
