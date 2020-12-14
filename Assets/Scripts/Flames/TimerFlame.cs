using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class TimerFlame : MonoBehaviour
{
    private float currentTime = 0f;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            if (currentTime / timer > 1)
            {
                SpawnFlames();
                currentTime = 0;
            }
            currentTime += 1 * Time.deltaTime;
        }
    }
    public void SpawnFlames()
    {
        GameManager.OnSpawnFlames();
    }
}
