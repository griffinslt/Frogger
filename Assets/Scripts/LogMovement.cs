using UnityEngine;

enum StartingSide
{
    LEFT = 0,
    RIGHT = 1,
}

public class LogMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private StartingSide startingSide;

    public LogMovement(string startingSide, int startingRow)
    {
        int x = 0;
        switch (startingSide)
        {
            case "left":
                this.startingSide = StartingSide.LEFT;
                x = 0; //actually be the leftmost part of the board

                break;
            case "right":
                this.startingSide = StartingSide.RIGHT;
                x = 10; //would actually be whatever the rightmost part of the board is
                break;
            default:
                break;
        }

        transform.position = new Vector2(x, startingRow);        

    }




    // Start is called before the first frame update
    void Awake()
    {
        // speed = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
