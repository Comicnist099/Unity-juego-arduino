using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFlyAway : MonoBehaviour
{
    float currentTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            currentTime += 1 * Time.deltaTime;
            if (currentTime / 3 > 1)
            {
                Destroy(gameObject);
                currentTime = 0;
            }
        }
    }
}
