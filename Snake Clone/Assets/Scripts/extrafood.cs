using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extrafood : MonoBehaviour
{
    public float delay = 5f;


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
          

           Destroy(gameObject);
        }

    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
           StartCoroutine(disablefood());
        }
    }


    private IEnumerator disablefood()
    {

        yield return new WaitForSeconds(delay);
        Destroy(gameObject);

    }
}
