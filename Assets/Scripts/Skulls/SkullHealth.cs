using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHealth : MonoBehaviour
{
    bool isInvicible;
    Animator animator;
    public GameObject flyaway;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.OnSkullMiss += MakeInvicible;
        GameManager.OnSkullShoot += MakeInvicible;
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
    public void KillSkull()
    {
        if (isInvicible == false)
        {
            animator.Play("Kill");
            GameManager.OnSkullShoot();

        }
    }
    public void MakeInvicible()
    {
        isInvicible = true;
    }
}
