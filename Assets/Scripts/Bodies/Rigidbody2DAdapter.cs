﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rigidbody2DAdapter : MonoBehaviour, IBody2D
{
    public float HorizontalSpeed => body.velocity.x;
    public float VerticalSpeed => body.velocity.y;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void PutHorizontalForce(float force)
    {
        var velocity = body.velocity;
        velocity.x = force;
        body.velocity = velocity;
    }

    public void PutVerticalForce(float force)
    {
        var velocity = body.velocity;
        velocity.y = force;
        body.velocity = velocity;
    }
}
