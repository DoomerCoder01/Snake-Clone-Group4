using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingFood : MonoBehaviour
{

    public BoxCollider2D _gridarea;
    public  GameObject _extrafood;
    public int _eatenFood; //counts the amount of times the player has eaten the food
    [SerializeField] private ParticleSystem _foodfeedback;
    public Text countdownText;
    public int countextrafood;
    public GameObject Speedfood;
    public bool isInstantiated=false;
    public AudioSource Au; 
    private void Start()
    {
        RandomisePosition();
    }



    private void RandomisePosition()
    {
        Bounds bounds = this._gridarea.bounds; //collider has bounds so we are referencnig the bounds

        float x = Random.Range(bounds.min.x, bounds.max.x); //now we are accessing any random number within these bounds between x and y  
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position= new Vector3(Mathf.Round(x),Mathf.Round(y),0); //need to round off vectors so that the food appears in a grid

    }
    public void RandomiseExtrafoodPosition()
    {
        ///_extrafood.gameObject.SetActive(true); //first turn on the extra food 

        Bounds bounds = this._gridarea.bounds; //collider has bounds so we are referencnig the bounds

        float x = Random.Range(bounds.min.x, bounds.max.x); //now we are accessing any random number within these bounds between x and y  
        float y = Random.Range(bounds.min.y, bounds.max.y);
       
        _extrafood.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0);

        Instantiate(_extrafood, _extrafood.transform.position,Quaternion.identity);

        //countdownText.gameObject.SetActive(true);

    }

    public void RandomiseSpeedFoodPosition()
    {

        Bounds bounds = this._gridarea.bounds; //collider has bounds so we are referencnig the bounds

        float x = Random.Range(bounds.min.x, bounds.max.x); //now we are accessing any random number within these bounds between x and y  
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Speedfood.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);

        Instantiate(Speedfood, Speedfood.transform.position, Quaternion.identity);

        ///countdownText.gameObject.SetActive(true);
        countextrafood = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomisePosition();
            _eatenFood++; //adds a single unit each time player collides with the food
            ///_foodfeedback.Play(); //plays the particlce affect when the player collides with the food
            Au = other.GetComponent<AudioSource>();
            Au.Play();
            if (_eatenFood==5)
            {
                
                RandomiseExtrafoodPosition(); //Spawn the extra food 

                _eatenFood = 0; //if the amount of food eaten is more then or equal to five reset the amount of food
            }
        }
        
        if (other.tag== "Body")
        {
            RandomisePosition(); 
        }
        if (other.tag=="Obstacle")
        {
            RandomisePosition();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Body")
        {
            ///RandomisePosition();
        }
    }
   
    private void Update()
    {
        if (_extrafood.activeInHierarchy)
        {
             isInstantiated = true;
        }
        else if (!_extrafood.activeInHierarchy)
        {
            isInstantiated = false;
        }
        if (countextrafood == 5 && !isInstantiated)
        {
            RandomiseSpeedFoodPosition();
            countextrafood = 0;
        }
    }
}
