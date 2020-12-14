using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSkulls : MonoBehaviour
{
    RaycastHit hit;

    private int bulletAnt;
    public int maxBullets;

    private SkullHealth health;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnSpawnSkulls += ResetBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletAnt--;

            if (bulletAnt <= 0)
            {
                GameManager.OnSkullMiss();
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.z;

            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Skull")
                {
                    health = hit.transform.GetComponent<SkullHealth>();
                    health.KillSkull();
                }
            }
        }
    }
    public void ResetBullets()
    {
        bulletAnt = maxBullets;
    }
}