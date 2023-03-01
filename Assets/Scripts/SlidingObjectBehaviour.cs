using System;
using UnityEngine;
using UnityEngine.UIElements;

internal enum StartingSide
{
    Left = 0,
    Right = 1,
}

[RequireComponent(typeof(Rigidbody2D))]
public class SlidingObjectBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;
    private StartingSide _startingSide;

    private Rigidbody2D _rb2d;
    private Vector2 _velocity;


    private void Start()
    {
        _rb2d.gravityScale = 0f;
    }

    private void Awake()
    {
        _startingSide = transform.position.x <= 0 ? StartingSide.Left : StartingSide.Right;
        _rb2d = GetComponent<Rigidbody2D>();
        _velocity = _rb2d.velocity;
        //speed = 1f;
        if (_startingSide == StartingSide.Left)
        {
            _velocity.x += speed;
        }
        else
        {
            _velocity.x -= speed;
        }

        _rb2d.velocity = _velocity;
    }
}
