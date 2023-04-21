using System;
using System.Collections.Generic;
using Commands;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;


[RequireComponent(typeof(Rigidbody2D))]
public class FrogMovement : MonoBehaviour, IEntity
{

    public UnityEvent<bool> onTriggerChange;
    [SerializeField] private AchievementManager achievementManager;
    [SerializeField] private float speed;
    [SerializeField] private ContactFilter2D filter;
    private Rigidbody2D _rb2D;
    private Vector2 _currentPos;
    private bool _onPlatform;
    private int _furthestTraveled;
    private bool _withLadyFrog;
    private int _numberOfJumps;
    private bool _died;


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
        public bool _died;
    }

    public void LoadData(float speed, Vector2 position, bool onPlatform, int furthestTraveled, bool withLadyFrog, int numberOfJumps, bool died)
    {
        this.speed = speed;
        _currentPos = position;
        _onPlatform = onPlatform;
        _furthestTraveled = furthestTraveled;
        _withLadyFrog = withLadyFrog;
        _numberOfJumps = numberOfJumps;
        transform.position = _currentPos;
        _died = died;

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

            CheckBorderCollision(collision);
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
        
        
        
        if (InputHandler.ForwardButtonPressed()) 
        {
            movement += new ForwardCommand(this, speed).Execute();
            NumOfForwardJumpsCheck();
        } 
        if (InputHandler.BackwardButtonPressed()) 
        {
            movement += new BackCommand(this,speed).Execute();
        } 
        if (InputHandler.RightButtonPressed()) 
        {
            movement += new RightCommand(this, speed).Execute();
        } 
        if (InputHandler.LeftButtonPressed()) 
        {
            movement += new LeftCommand(this, speed).Execute();
            
        }

        _currentPos += movement;
        transform.position = _currentPos;
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
                case 100:
                    var achievement = Achievements.FindAchievementByName("100 Jumps");
                    achievementManager.NotifyAchievementComplete(achievement);
                    break;
                case 250:
                    achievementManager.NotifyAchievementComplete(Achievements.FindAchievementByName("250 Jumps"));
                    break;
                case 500:
                    achievementManager.NotifyAchievementComplete(Achievements.FindAchievementByName("500 Jumps"));
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
            transform.position = Vector2.zero;
        }
    }

    private void CheckTurtleCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Turtle"))
        {
            _rb2D.velocity = collision.GetComponent<Rigidbody2D>().velocity;
            _onPlatform = true;
            transform.position = collision.transform.position;
        }
    }
    private void CheckLogCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Log"))
        {
            _onPlatform = true;
            _rb2D.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

        }
    }

    private void CheckRiverCollision(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("River") || _onPlatform) return;
            _rb2D.velocity = Vector2.zero;
            transform.position = new Vector2(0, 0);
            _died = true;

        }

        
        private void CheckCarCollision(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Car"))
            {
                transform.position = new Vector2(0, 0);
            }

        }
        
        private void CheckBorderCollision(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("LeftBarrier"))
            {
                transform.position = new Vector2(_currentPos.x+1, _currentPos.y);
                _rb2D.velocity = Vector2.zero;
            }

            if (collision.gameObject.CompareTag("RightBarrier"))
            {
                transform.position = new Vector2(_currentPos.x-1, _currentPos.y);
                _rb2D.velocity = Vector2.zero;
            }

            if (collision.gameObject.CompareTag("UpBarrier"))
            { 
                transform.position = new Vector2(_currentPos.x, _currentPos.y -1);
            }
            if (collision.gameObject.CompareTag("DownBarrier"))
            {
                transform.position = new Vector2(_currentPos.x, _currentPos.y + 1);
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
                _onPlatform = _onPlatform,
                _died = _died,
            };

            return JsonUtility.ToJson(data);
        }





}