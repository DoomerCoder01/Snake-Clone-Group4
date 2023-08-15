using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments;
    public Transform _segmentPrefab;
    public TestingFood _NumEatenfood;
    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform); 
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        for (int i = _segments.Count -1; i >0 ; i--) //allows us to instantiate objects and move them in reverse order
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
           Mathf.Round(this.transform.position.x + _direction.x), //round the values to whole numbers helps give the game feel like its on a grid
           Mathf.Round(this.transform.position.y + _direction.y),
           0.0f
            );
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
            Resetstate();
        }
        else if (other.tag=="extrafood")
        {
            Grow(); //suppised to replace this function with one that grows twice the sections on the snake
        }

    }
}