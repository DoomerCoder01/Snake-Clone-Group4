using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class extrafood : MonoBehaviour
{
    public float delay = 5f;
    [SerializeField] private ParticleSystem _feedback;
    public Text countdownText;
    private float timeLeft = 5.0f;
    public TestingFood randomizextrafood;
    public TestingFood Countextrafood;
    public AudioSource Au;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _feedback.Play(); //plays the particlce affect when the player collides with the food
            Au = other.GetComponent<AudioSource>();
            Au.Play();
            countdownText.text="";
            Countextrafood.isInstantiated = false;
            Countextrafood.countextrafood++;
            Destroy(gameObject);
            GameObject[] objectswithtag = GameObject.FindGameObjectsWithTag("extrafood");
            foreach (GameObject obj in objectswithtag)
            {
                Destroy(obj);
            }
        }
        if (other.tag=="Body")
        {
            randomizextrafood.RandomiseExtrafoodPosition(); //if object collides with snake body it should reposition it self
        }
        if (other.tag=="Obstacle")
        {
            randomizextrafood.RandomiseExtrafoodPosition();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag=="Body")
        {
           /// randomizextrafood.RandomiseExtrafoodPosition();
        }
    }
    private void Update()
    {
        randomizextrafood= GameObject.FindGameObjectWithTag("Food").GetComponent<TestingFood>();

        countdownText = GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>();
        if (gameObject.activeSelf)
        {
           StartCoroutine(disablefood());
        }
        timeLeft -= Time.deltaTime;
        countdownText.text = Mathf.Round(timeLeft).ToString();

        Countextrafood = GameObject.FindGameObjectWithTag("Food").GetComponent<TestingFood>();
        Countextrafood.isInstantiated=true;

        GameObject[] objectswithtag = GameObject.FindGameObjectsWithTag("extrafood");
    }


    private IEnumerator disablefood()
    {

        yield return new WaitForSeconds(delay);
        Countextrafood.isInstantiated = false;
        countdownText.text="";
        GameObject[] objectswithtag = GameObject.FindGameObjectsWithTag("extrafood");
        foreach (GameObject obj in objectswithtag)
        {
            Destroy(obj);
        }



        Destroy(gameObject);

    }
}
