using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCountdown : MonoBehaviour
{
    // Start is called before the first frame update
    public Text countdownText;
    private float timeLeft = 5.0f;
   
    void Update()
    {
        countdownText = GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>();
        if (gameObject.activeInHierarchy)
        {
            timeLeft -= Time.deltaTime;
            countdownText.text = Mathf.Round(timeLeft).ToString();
            if (timeLeft < 0)
            {
                gameObject.SetActive(false);
            }
        }
        else if (!gameObject.activeInHierarchy)
        {
            countdownText = null;
        }
    }
}
