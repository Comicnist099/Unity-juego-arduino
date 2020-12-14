using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFlame : MonoBehaviour
{
    public GameObject flame;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnSpawnFlames += SpawnFlame;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnFlame()
    {
        Instantiate(flame, gameObject.transform.position, Quaternion.identity);
    }

}
