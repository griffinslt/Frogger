using System;
using UnityEngine;

internal enum StartingSide
{
    Left = 0,
    Right = 1,
}

[RequireComponent(typeof(Rigidbody2D))]
public class LogMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private StartingSide startingSide;

    private Rigidbody2D _rb2d;
    private Vector2 _velocity;
    

    /**
     * Constructor - not sure how this can be used yet
     */
    public LogMovement(string startingSide, int startingRow)
    {
        var xStart = 0;
        switch (startingSide)
        {
            case "left":
                this.startingSide = StartingSide.Left;
                xStart = 0; //actually be the leftmost part of the board

                break;
            case "right":
                this.startingSide = StartingSide.Right;
                xStart = 10; //would actually be whatever the rightmost part of the board is
                break;
        }

        transform.position = new Vector2(xStart, startingRow);
    }
    
    




    // Start is called before the first frame update
    private void Awake()
    {
        print("i'm awake");
        transform.position = new Vector2(0, 2); //should actually be dictated by the spawner
        _rb2d = GetComponent<Rigidbody2D>();
        _velocity = _rb2d.velocity;
        speed = 1f;
        if (startingSide == StartingSide.Left)
        {
            _velocity.x += speed;
        }
        else
        {
            _velocity.x -= speed;
        }

        _rb2d.velocity = _velocity;
    }

    public void Construct(string startingSide, int startingRow)
    {
        var xStart = 0;
        switch (startingSide)
        {
            case "left":
                this.startingSide = StartingSide.Left;
                xStart = 0; //actually be the leftmost part of the board

                break;
            case "right":
                this.startingSide = StartingSide.Right;
                xStart = 10; //would actually be whatever the rightmost part of the board is
                break;
        }

        transform.position = new Vector2(xStart, startingRow);
    }
}
