using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuevo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f),Mathf.Clamp(transform.position.y,-4.2f,4.2f),transform.position.z);
    }
}