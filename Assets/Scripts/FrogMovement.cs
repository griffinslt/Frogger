using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour
{

    public UnityEvent<bool> onTriggerChange;
    [SerializeField] private float speed;
    Rigidbody2D rb2D;
    private Vector2 currentPos;

    private void Awake()
    {
        print("awake player");
        rb2D = GetComponent<Rigidbody2D>();
        currentPos = transform.position;
        print(currentPos);
        
    }

    private void Update()
    {
        CheckMovement();
        
    }

    private void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            transform.eulerAngles = new Vector3(0,0,0);
            transform.position = currentPos + new Vector2(0,1);
            currentPos += new Vector2(0,1);
        } else if (Input.GetKeyDown(KeyCode.S)) 
        {
            transform.eulerAngles = new Vector3(0,0,180);
            transform.position = currentPos + new Vector2(0,-1);
            currentPos += new Vector2(0,-1);
        } else if (Input.GetKeyDown(KeyCode.D)) 
        {
            transform.eulerAngles = new Vector3(0,0,-90);
            transform.position = currentPos + new Vector2(1,0);
            currentPos += new Vector2(1, 0);
        } else if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform.eulerAngles = new Vector3(0,0,90);            
            transform.position = currentPos + new Vector2(-1,0);
            currentPos += new Vector2(-1, 0);
            
        }

    }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            print(collision.gameObject.tag);
            
            onTriggerChange?.Invoke(true);
        }

      
        private void OnTriggerExit2D(Collider2D collision)
        {
            print("off trigger");
            onTriggerChange?.Invoke(false);
        }

    
}