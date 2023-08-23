using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform _segmentPrefab;
    public TestingFood _NumEatenfood;
    [SerializeField] private ParticleSystem _feedback;
    public int _initialSize = 4;
    public ScreenBounds screenBunds;
    Vector3 tempPos;
    private bool InputActive = true;
    public float reactiveatetime = 0.1f;
    private void Start()
    {
        Resetstate();
    }

    private void Update()
    {
        if (InputActive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (_direction != Vector2.down) //makes sure that the player doesnt collide with self
                {
                    _direction = Vector2.up;

                    InputActive = false;
                    Invoke("ResetInputActive", reactiveatetime);
                }

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                if (_direction != Vector2.up)
                {
                    _direction = Vector2.down;


                    InputActive = false;
                    Invoke("ResetInputActive", reactiveatetime);
                }

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (_direction != Vector2.right)
                {
                    _direction = Vector2.left;


                    InputActive = false;
                    Invoke("ResetInputActive", reactiveatetime);
                }

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (_direction != Vector2.left)
                {
                    _direction = Vector2.right;


                    InputActive = false;
                    Invoke("ResetInputActive", reactiveatetime);
                }

            }
        }
        

    }
    private void ResetInputActive()
    {
        InputActive = true;
    }
    private void FixedUpdate()
    {
        tempPos = new Vector3(
          Mathf.Round(this.transform.localPosition.x + _direction.x), //round the values to whole numbers helps give the game feel like its on a grid
          Mathf.Round(this.transform.localPosition.y + _direction.y),
          0.0f
           );

        for (int i = _segments.Count -1; i >0 ; i--) //allows us to instantiate objects and move them in reverse order
        {
            _segments[i].position = _segments[i - 1].position;
        }

        if (screenBunds.OutOfBounds(tempPos))
        {
            Vector2 newPosition = screenBunds.CalculateWrappedPos(tempPos);
            
            transform.position = newPosition;
        }
        else
        {
            transform.position = tempPos;
        }
    }
    
    private void Grow()
    {
        Transform segment =Instantiate(this._segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);

    }
    private void Resetstate()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].transform.gameObject);

        }
        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;

        for (int i  = 1; i  < this._initialSize; i ++)
        {
            _segments.Add(Instantiate(this._segmentPrefab));
        }
        //add a reference to food script to reset the amount of food eaten to zero
        _NumEatenfood._eatenFood = 0; //resets the amount of food eaten
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag== "Obstacle")
        {
            ///
        }
        else if (other.tag=="extrafood")
        {
            Grow(); //suppised to replace this function with one that grows twice the sections on the snake
            _feedback.Play(); //plays the particlce affect when the player collides with the food
            Grow(); //call on it twice so that the snake grows twice when colliding with special food
            Grow();
            Grow();
            _NumEatenfood._eatenFood = 0;
        }
        else if (other.tag=="Body")
        {
            //add restart here
            ///Resetstate();
        }
    }
}
