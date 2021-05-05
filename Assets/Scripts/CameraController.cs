using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, transform.transform.position.y, this.transform.position.z);
    }
}
