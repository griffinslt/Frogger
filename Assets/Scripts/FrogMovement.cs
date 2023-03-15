using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;


[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour
{

    public UnityEvent<bool> onTriggerChange;
    [SerializeField] private float speed;
    private Rigidbody2D _rb2D;
    private Vector2 _currentPos;
    private bool _immuneToWater = false;

    private void Awake()
    {
        print("awake player");
        _rb2D = GetComponent<Rigidbody2D>();
        _currentPos = transform.position;
        print(_currentPos);
        
    }

    private void Update()
    {
        CheckMovement();

        // Vector3Int groundMap = ground.WorldToCell();
    }

    private void CheckMovement()
    {
        Vector2 movement = new Vector2(0, 0);
        
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            transform.eulerAngles = new Vector3(0,0,0);
            transform.position = _currentPos + new Vector2(0,1);
            movement += new Vector2(0,1);
        } 
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            transform.eulerAngles = new Vector3(0,0,180);
            transform.position = _currentPos + new Vector2(0,-1);
            movement += new Vector2(0,-1);
        } 
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            transform.eulerAngles = new Vector3(0,0,-90);
            transform.position = _currentPos + new Vector2(1,0);
            movement += new Vector2(1, 0);
        } 
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.eulerAngles = new Vector3(0,0,90);            
            transform.position = _currentPos + new Vector2(-1,0);
            movement += new Vector2(-1, 0);
            
        }

        _currentPos += movement;

    }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckCarCollision(collision);
            onTriggerChange?.Invoke(true);
            CheckLogCollision(collision);
            onTriggerChange?.Invoke(true);
            CheckRiverCollision(collision);
            
            
            onTriggerChange?.Invoke(true);

            
        }

        private void CheckRiverCollision(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("River") && !_immuneToWater)
            {
                print("in the river died");
            }
            
        }

        private void CheckLogCollision(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Log"))
            {
                print("log");
                _rb2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                _immuneToWater = true;
            }
        }

        private void CheckCarCollision(Collider2D collision)
        {
            
                if (collision.gameObject.CompareTag("Car"))
                {
                    print("you died");

                }
            
        }

      
        private void OnTriggerExit2D(Collider2D collision)
        {
            CheckRiverCollision(collision);
            _rb2D.velocity = new Vector2(0, 0);
            // print("off trigger");
            _immuneToWater = false;
            onTriggerChange?.Invoke(false);
        }
        
    
        
        

    
}