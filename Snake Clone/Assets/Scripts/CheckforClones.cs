using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforClones : MonoBehaviour
{
    public GameObject objectToCheck;
    private List<GameObject> clones = new List<GameObject>();

    void Update()
    {
        clones.Clear();
        foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.name == objectToCheck.name + "(Clone)" || obj.tag == objectToCheck.tag) 
            {
                clones.Add(obj);
            }
        }

        if (clones.Count > 1)
        {
            for (int i = 1; i < clones.Count; i++)
            {
                Destroy(clones[i]);
            }
        }
    }

}
