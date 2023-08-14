using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingFood : MonoBehaviour
{

    public BoxCollider2D _gridarea;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomisePosition();
        }
      
    }
}
