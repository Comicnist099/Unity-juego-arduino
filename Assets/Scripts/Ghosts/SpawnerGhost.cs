using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGhost : MonoBehaviour
{
    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnSpawnGhosts += SpawnGhost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGhost()
    {
        Instantiate(ghost, gameObject.transform.position, Quaternion.identity);
    }

}
