using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMovement : MonoBehaviour
{
    public float speed;
    public Vector3 direction;

    private int bounce;
    public int bounceMax;
    private bool fall;
    private float currentTime;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnSkullShoot += StopMovement;
        GameManager.OnSkullMiss += FlyAway;
        RandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        if (gameObject.transform.position.y >= 9 || gameObject.transform.position.y <= -7.40f)
            boxCollider.isTrigger = false;
        gameObject.transform.position += direction * speed;
        if (fall == true)
        {
            currentTime += 1 * Time.deltaTime;
        }
        if (currentTime >= 1.5)
        {
            StartFall();
        }
    }

    public void RandomDirection()
    {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(.2f, .9f), 0);
    }

    public void DirectionChanger(Vector3 _dir)
    {
        direction = new Vector3(direction.x * _dir.x, direction.y * _dir.y, 0);
        speed = Random.Range(.01f, .02f);

        bounce++;
        if (bounce >= bounceMax)
        {
            direction = new Vector3(0, 1, 0);
            GameManager.OnSkullMiss();
        }
    }
    public void StopMovement()
    {
        direction = new Vector3(0, 0, 0);
        fall = true;
    }
    public void StartFall()
    {
        direction = new Vector3(0, -1, 0);
        boxCollider.enabled = true;
    }
    public void FlyAway()
    {
        direction = new Vector3(0, 1, 0);
        if(boxCollider!=null)
            boxCollider.isTrigger = true;
    }
}