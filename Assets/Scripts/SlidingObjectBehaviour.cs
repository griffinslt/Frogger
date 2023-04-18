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
    [Serializable]
    private struct ClassData
    {
        public float speed;
        public int _ids;
        public int id;
        public float currentX;
        public float currentY;
    }
    [SerializeField] private float speed;
    [SerializeField] private static int _ids = 0;
    [SerializeField] private int id;

    private void Awake()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
        id = _ids++;
        var startingSide = transform.position.x <= 0 ? StartingSide.Left : StartingSide.Right;
        var velocity = rb2d.velocity;
        if (startingSide == StartingSide.Left)
        {
            velocity.x += speed;
        }
        else
        {
            velocity.x -= speed;
        }

        rb2d.velocity = velocity;
        
        if (id <= 2)
        {
            rb2d.velocity = Vector2.zero;
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

    public string ToJson()
    {
        var position = transform.position;
        var data = new ClassData
        {
            speed = speed,
            _ids = _ids,
            id = id,
            currentX = position.x,
            currentY = position.y,
        };

        return JsonUtility.ToJson(data);

    }
}
