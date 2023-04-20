using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour
{

    public UnityEvent<bool> onTriggerChange;
    [SerializeField] private AchievementManager achievementManager;
    [SerializeField] private float speed;
    [SerializeField] private ContactFilter2D filter;
    private Rigidbody2D _rb2D;
    private Vector2 _currentPos;
    private bool _onPlatform;
    private int _furthestTraveled;
    // public ScoreKeeper scoreKeeper;
    // public HomeFrogSpawner homeFrogSpawner;
    private bool _withLadyFrog;
    private int _numberOfJumps;


    [Serializable]
    private struct FrogData
    {
        public float speed;
        public float CurrentPositionX;
        public float CurrentPositionY;
        public int _furthestTraveled;
        public bool _withLadyFrog;
        public int _numberOfJumps;
        public bool _onPlatform;
        //Todo figure out how score keeper and homefrog spawner can stay connected - home frog spawner can be static
    }

    public void LoadData(float speed, Vector2 position, bool onPlatform, int furthestTraveled, bool withLadyFrog, int numberOfJumps)
    {
        this.speed = speed;
        _currentPos = position;
        _onPlatform = onPlatform;
        _furthestTraveled = furthestTraveled;
        _withLadyFrog = withLadyFrog;
        _numberOfJumps = numberOfJumps;
        transform.position = _currentPos;

    }

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _currentPos = transform.position;
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            CheckMovement();
            CheckCollisions();
        }
        
    }

    private void LateUpdate()
    {
        List<Collider2D> collider2Ds = new List<Collider2D>();
        Physics2D.OverlapPoint(_currentPos, filter, collider2Ds);
        foreach (var collision in collider2Ds)
        {
            if (!_onPlatform)
            {
                CheckRiverCollision(collision);
            }
        }
    }
    

    private void NumOfForwardJumpsCheck()
    {
        if (_furthestTraveled < _currentPos.y)
        {
            _furthestTraveled = (int) _currentPos.y;
            ScoreKeeper.Instance.AddScore(10);
        }
        
    }

    private Vector2 RoundPosition(Vector3 position)
    {
        if (!_onPlatform)
        {
            float x = (float)Math.Round(position.x);
            float y = (float)Math.Round(position.y);
            return new Vector2(x, y);
        }

        return position;
        
    }

    private void CheckMovement()
    {
        _currentPos = transform.position;
        Vector2 movement = new Vector2(0, 0);
        var transform1 = transform;
        
        
        
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            transform1.eulerAngles = new Vector3(0,0,0);
            transform1.position = _currentPos + new Vector2(0,speed);
            movement += new Vector2(0,speed);
            NumOfForwardJumpsCheck();
        } 
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            transform1.eulerAngles = new Vector3(0,0,180);
            transform1.position = _currentPos + new Vector2(0,-speed);
            movement += new Vector2(0,-speed);
        } 
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            transform1.eulerAngles = new Vector3(0,0,-90);
            transform1.position = _currentPos + new Vector2(speed,0);
            movement += new Vector2(speed, 0);
        } 
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            transform1.eulerAngles = new Vector3(0,0,90);            
            transform1.position = _currentPos + new Vector2(-speed,0);
            movement += new Vector2(-speed, 0);
            
        }

        _currentPos += movement;
        if (movement.magnitude > 0)
        {
            _numberOfJumps++;
            JumpAchievementCheck();
        }
        
        
    }

    private void JumpAchievementCheck()
    {
        try
        {
            switch (_numberOfJumps)
            {
                case 10:
                    var achievement = Achievements.FindAchievementByName("10 Jumps");
                    achievementManager.NotifyAchievementComplete(achievement);
                    break;
                case 50:
                    achievementManager.NotifyAchievementComplete(Achievements.FindAchievementByName("50 Jumps"));
                    break;
                case 100:
                    achievementManager.NotifyAchievementComplete(Achievements.FindAchievementByName("100 Jumps"));
                    break;
            }
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
            print("does not exist");
        }
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void CheckCollisions()
    {
        List<Collider2D> collider2Ds = new List<Collider2D>();
        Physics2D.OverlapPoint(_currentPos, filter, collider2Ds);
        foreach (var collision in collider2Ds)
        {
            CheckCarCollision(collision);
            CheckLogCollision(collision);
            CheckTurtleCollision(collision);
            // if (!_onPlatform)
            // {
            //     CheckRiverCollision(collision);
            // }
           



        }

    }

    private void CheckHomeCollision(Collider2D collision)
    {
        if (collision.CompareTag("Home"))
        {
            
            Home home = collision.GetComponent<Home>();
            

            if (_withLadyFrog && !home.HasBeenVisitedWithLady())
            {
                home.VisitWithLady();
                ScoreKeeper.Instance.AddScore(200);
                _withLadyFrog = false;
            }
            else if (!home.HasBeenVisited())
            {
                HomeFrogSpawner.Instance.SpawnHomeFrog(collision.transform);
                ScoreKeeper.Instance.AddScore(50);
            }
            home.Visit();
        }
    }

    private void CheckTurtleCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Turtle"))
        {
            //print("on turtle");
            _rb2D.velocity = collision.GetComponent<Rigidbody2D>().velocity;
            _onPlatform = true;
            transform.position = collision.transform.position;
        }
    }
    private void CheckLogCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            print("on log");
            _onPlatform = true;
            _rb2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

        }
    }


    // private void OnTriggerEnter2D(Collider2D collision)
        // {
        //     CheckCarCollision(collision);
        //     CheckLogCollision(collision);
        //     CheckRiverCollision(collision);
        //     onTriggerChange?.Invoke(true);
        //
        //     
        // }

        private void CheckRiverCollision(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("River") || _onPlatform) return;
            _rb2D.velocity = Vector2.zero;
            transform.position = new Vector2(0, 0);

        }

        
        private void CheckCarCollision(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Car"))
            {
                transform.position = new Vector2(0, 0);
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckHomeCollision(collision);
        }


        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Log") || collision.CompareTag("Turtle"))
            {
                OffPlatform();
            }
           
            onTriggerChange?.Invoke(false);
        }

        private void OffPlatform()
        {
            _rb2D.velocity = new Vector2(0, 0);
            _onPlatform = false;
            transform.position = RoundPosition(transform.position);
        }

        public string ToJson()
        {
            var data = new FrogData()
            {
                speed = speed,
                _furthestTraveled = _furthestTraveled,
                _withLadyFrog = _withLadyFrog,
                CurrentPositionX = _currentPos.x,
                CurrentPositionY = _currentPos.y,
                _numberOfJumps = _numberOfJumps,
                _onPlatform = _onPlatform
            };

            return JsonUtility.ToJson(data);
        }





}