using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingFood : MonoBehaviour
{

    public BoxCollider2D _gridarea;
    public  GameObject _extrafood;
    public int _eatenFood; //counts the amount of times the player has eaten the food
   

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
    private void RandomiseExtrafoodPosition()
    {
        ///_extrafood.gameObject.SetActive(true); //first turn on the extra food 

        Bounds bounds = this._gridarea.bounds; //collider has bounds so we are referencnig the bounds

        float x = Random.Range(bounds.min.x, bounds.max.x); //now we are accessing any random number within these bounds between x and y  
        float y = Random.Range(bounds.min.y, bounds.max.y);
       
        _extrafood.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0);

        Instantiate(_extrafood, _extrafood.transform.position,Quaternion.identity);

       
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomisePosition();
            _eatenFood++; //adds a single unit each time player collides with the food
            if (_eatenFood==5)
            {
                
                RandomiseExtrafoodPosition(); //Spawn the extra food 

                _eatenFood = 0; //if the amount of food eaten is more then or equal to five reset the amount of food
            }
        }

    }

   

}
