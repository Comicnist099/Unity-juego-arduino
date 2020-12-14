using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChangerSkulls : MonoBehaviour
{
    public enum DirChanger
    {
        Horizontal,
        Vertical
    }
    public DirChanger changer;
    public SkullMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnSkullShoot += TurnOff;
        GameManager.OnSkullMiss += TurnOff;
        GameManager.OnSpawnSkulls += TurnOn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Skull")
        {
            movement = hit.gameObject.GetComponent<SkullMovement>();
            if (changer == DirChanger.Horizontal)
            {
                movement.DirectionChanger(new Vector3(-1, 1, 0));
            }
            else if (changer == DirChanger.Vertical)
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

