using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFlash : MonoBehaviour
{
    public Color flashColor1;
    public Color flashColor2;
    private SpriteRenderer spriteRenderer;
    public GameObject[] bodyObjects;
    private Color[] originalColors; // The original colors of the body objects

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Update bodyObjects array
        bodyObjects = GameObject.FindGameObjectsWithTag("Body");

        // Update originalColors array
        originalColors = new Color[bodyObjects.Length];
        for (int i = 0; i < bodyObjects.Length; i++)
        {
            SpriteRenderer bodySpriteRenderer = bodyObjects[i].GetComponent<SpriteRenderer>();
            if (bodySpriteRenderer != null)
            {
                originalColors[i] = bodySpriteRenderer.color;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("speedfood"))
        {
            StartCoroutine(Flash());
        }
    }

    IEnumerator Flash()
    {
        float flashDuration = 10f; // The total duration of the flashing in seconds
        float flashInterval = 0.5f; // The duration of each individual flash in seconds
        float timer = 0f;

        while (timer < flashDuration)
        {
            Color color = (timer / flashInterval) % 2 == 0 ? flashColor1 : flashColor2;
            spriteRenderer.color = color;
            foreach (GameObject bodyObject in bodyObjects)
            {
                bodyObject.GetComponent<SpriteRenderer>().color = color;
            }
            timer += flashInterval;
            yield return new WaitForSecondsRealtime(flashInterval);
        }

        // Restore the original colors of the body objects after flashing is done
        for (int i = 0; i < bodyObjects.Length; i++)
        {
            SpriteRenderer bodySpriteRenderer = bodyObjects[i].GetComponent<SpriteRenderer>();
            if (bodySpriteRenderer != null)
            {
                bodySpriteRenderer.color = originalColors[i];
            }
        }
    }
}
