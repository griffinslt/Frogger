using System;
using UnityEngine;
using UnityEngine.Serialization;


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
    private static int _ids = 0;
    [SerializeField] private int id;


    private void Start()
    {
        _rb2d.gravityScale = 0f;
    }

    private void Awake()
    {
        id = _ids++;
        _startingSide = transform.position.x <= 0 ? StartingSide.Left : StartingSide.Right;
        _rb2d = GetComponent<Rigidbody2D>();
        _velocity = _rb2d.velocity;
        if (_startingSide == StartingSide.Left)
        {
            _velocity.x += speed;
        }
        else
        {
            _velocity.x -= speed;
        }

        _rb2d.velocity = _velocity;
        
        if (id <= 2)
        {
            _rb2d.velocity = Vector2.zero;
        }
        
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
        if (x > 10 && this.id > 2)
        {
            return false;
        }

        

        return true;
    }

    public Vector2 GetVelocity()
    {
        return _velocity;
    }
}
