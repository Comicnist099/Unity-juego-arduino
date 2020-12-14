using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    public enum DirChanger
    {
        Horizontal,
        Vertical
    }
    public DirChanger changer;
    public GhostMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGhostShoot += TurnOff;
        GameManager.OnGhostMiss += TurnOff;
        GameManager.OnSpawnGhosts += TurnOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.transform.tag=="Ghost")
        {
            movement = hit.gameObject.GetComponent<GhostMovement>();
            if (changer==DirChanger.Horizontal)
            {
                movement.DirectionChanger(new Vector3(-1, 1, 0));
            }
            else if(changer==DirChanger.Vertical)
            {
                movement.DirectionChanger(new Vector3(1, -1, 0));
            }
        }
    }
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
}
