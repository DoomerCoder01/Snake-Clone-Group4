using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamerestart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject restartMenu;
    public Color flashColor1;
    public Color flashColor2;
    private SpriteRenderer spriteRenderer;
    public GameObject[] bodyObjects;
    public bool Gameover= false;
    void Start()
    {
        bodyObjects = GameObject.FindGameObjectsWithTag("Body");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        bodyObjects = GameObject.FindGameObjectsWithTag("Body");


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            StartCoroutine(Flash());
            Gameover = true;
        }
        else if (other.tag=="Body")
        {
            StartCoroutine(Flash());
            Gameover=true;
        }  
    }

    IEnumerator Flash()
    {
        Time.timeScale = 0;
        for (int i = 0; i < 6; i++)
        {
            spriteRenderer.color = (i % 2 == 0) ? flashColor1 : flashColor2;
            foreach (GameObject bodyObject in bodyObjects)
            {
                bodyObject.GetComponent<SpriteRenderer>().color = (i % 2 == 0) ? flashColor1 : flashColor2;
            }
            yield return new WaitForSecondsRealtime(0.9f);
        }
        ///Time.timeScale = 1;
        Gameover = true;
        restartMenu.SetActive(true);
    }
}
