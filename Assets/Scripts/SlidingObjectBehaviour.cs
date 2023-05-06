using System;
using UnityEngine;
using UnityEngine.Serialization;


internal enum StartingSide
{
    Left = 1,
    Right = 2,
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
        public int startingSide;
    }
    [SerializeField] private float speed;
    public static int _ids;
    [SerializeField] private int id;
    private StartingSide startingSide;
    private Rigidbody2D rb2d;

    public void Load(float speed, int ids, int id)
    {
        this.speed = speed;
        this.id = id;
    }

    

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
        id = _ids;
        _ids++;
        startingSide = transform.position.x <= 0 ? StartingSide.Left : StartingSide.Right;
        var velocity = rb2d.velocity;
        if (transform.rotation.z == 0)
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

    private void LateUpdate()
    {
        if (!CheckInBounds())
        {
            if (gameObject.name == "clone")
            {
                Destroy(gameObject);
            }
           
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
            speed = rb2d.velocity.magnitude,
            _ids = _ids,
            id = id,
            currentX = position.x,
            currentY = position.y,
            startingSide = (int) startingSide,
        };

        return JsonUtility.ToJson(data);

    }
}
