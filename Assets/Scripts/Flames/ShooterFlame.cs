using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFlame : MonoBehaviour
{
    RaycastHit hit;

    private int bulletAnt;
    public int maxBullets;

    private FlameHealth health;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnSpawnFlames += ResetBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletAnt--;

            if (bulletAnt <= 0)
            {
                GameManager.OnFlameMiss();
            }

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.z;

            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Flame")
                {
                    health = hit.transform.GetComponent<FlameHealth>();
                    health.KillFlame();
                }
            }
        }
    }
    public void ResetBullets()
    {
        bulletAnt = maxBullets;
    }
}
