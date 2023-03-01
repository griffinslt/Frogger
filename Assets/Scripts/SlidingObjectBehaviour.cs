using System;
using UnityEngine;


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
    private static int ids = 0;
    private int _id;


    private void Start()
    {
        _rb2d.gravityScale = 0f;
    }

    private void Awake()
    {
        _id = ids++;
        print(_id);
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

    private void Update()
    {
        if (!CheckInBounds())
        {
            Destroy(gameObject);
        }
    }

    private bool CheckInBounds()
    {
        var x = Math.Abs(transform.position.x);
        if (x > 8 && _id > 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
