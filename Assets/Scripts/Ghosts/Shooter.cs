using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    RaycastHit hit;

    private int bulletAnt;
    public int maxBullets;

    private GhostHealth health;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnSpawnGhosts += ResetBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bulletAnt--;

            if(bulletAnt <= 0)
            {
                GameManager.OnGhostMiss();
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.z;

            if(Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Ghost")
                {
                    health = hit.transform.GetComponent<GhostHealth>();
                    health.KillGhost();
                }
            }
        }
    }
    public void ResetBullets()
    {
        bulletAnt = maxBullets;
    }
}
