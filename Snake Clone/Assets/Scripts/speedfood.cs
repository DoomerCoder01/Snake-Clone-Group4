using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedfood : MonoBehaviour
{
    public float delay = 5f;
    [SerializeField] private ParticleSystem _feedback;
    public Text countdownText;
    private float timeLeft = 5.0f;
    public float speedincrease = 0.05f;
    public  AudioSource Au;
    public TestingFood randomizextrafood;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _feedback.Play(); //plays the particlce affect when the player collides with the food
            Au = other.GetComponent<AudioSource>();
            Au.Play();
            countdownText.text="";
            Time.fixedDeltaTime = speedincrease; //

            Destroy(gameObject);
        }
        if (other.tag=="Obstacle")
        {
            randomizextrafood.RandomiseSpeedFoodPosition(); //if object collides with snake body it should reposition it self
        }
        if (other.tag=="Body")
        {
            randomizextrafood.RandomiseSpeedFoodPosition(); //if object collides with snake body it should reposition it self
        }
    }
    private void Update()
    {
        countdownText = GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>();
        if (gameObject.activeSelf)
        {
            StartCoroutine(disablefood());
        }
        timeLeft -= Time.deltaTime;
        countdownText.text = Mathf.Round(timeLeft).ToString();
        randomizextrafood = GameObject.FindGameObjectWithTag("Food").GetComponent<TestingFood>();
    }


    private IEnumerator disablefood()
    {

        yield return new WaitForSeconds(delay);

        countdownText.text="";
        Destroy(gameObject);

    }
}
