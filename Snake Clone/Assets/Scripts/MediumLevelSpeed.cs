using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumLevelSpeed : MonoBehaviour
{
    public float speed = 0.075f;

    public Text countdownText;
    private float timeLeft = 10.0f;

    void Start()
    {
        Time.fixedDeltaTime = speed;
    }

    void Update()
    {
        if (Time.fixedDeltaTime != speed)
        {
            countdownText.gameObject.SetActive(true);
            timeLeft -= Time.deltaTime;
            countdownText.text = Mathf.Round(timeLeft).ToString();
        }

        if (timeLeft <= 0)
        {
            countdownText.text="";
            Time.fixedDeltaTime = speed;
        }
    }
}
