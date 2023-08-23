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
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _feedback.Play(); //plays the particlce affect when the player collides with the food

            countdownText.gameObject.SetActive(false);


            Destroy(gameObject);
        }
        if (other.tag=="Body")
        {
            randomizextrafood.RandomiseExtrafoodPosition(); //if object collides with snake body it should reposition it self
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

    }


    private IEnumerator disablefood()
    {

        yield return new WaitForSeconds(delay);
        
        countdownText.gameObject.SetActive(false);
        Destroy(gameObject);

    }
}
