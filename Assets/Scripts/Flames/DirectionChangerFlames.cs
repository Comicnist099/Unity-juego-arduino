using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChangerFlames : MonoBehaviour
{
    public enum DirChanger
    {
        Horizontal,
        Vertical
    }
    public DirChanger changer;
    public FlameMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnFlameShoot += TurnOff;
        GameManager.OnFlameMiss += TurnOff;
        GameManager.OnSpawnFlames += TurnOn;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.transform.tag == "Flame")
        {
            movement = hit.gameObject.GetComponent<FlameMovement>();
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
