using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyLevelSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.099999f;
    }

}
