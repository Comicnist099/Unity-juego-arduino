﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHealth : MonoBehaviour
{
    bool isInvicible;
    Animator animator;
    public GameObject flyaway;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.OnFlameMiss += MakeInvicible;
        GameManager.OnFlameShoot += MakeInvicible;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "KillZoneTag")
        {
            Destroy(gameObject);
        }
        if (hit.tag == "FlyZone")
        {
            Instantiate(flyaway, new Vector3(0.2797674f, 3.991804f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void KillFlame()
    {
        if (isInvicible == false)
        {
            animator.Play("Kill");
            GameManager.OnFlameShoot();
        }
    }
    public void MakeInvicible()
    {
        isInvicible = true;
    }
}
