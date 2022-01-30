using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFall : MonoBehaviour
{
    float h = 0;
    public float koeff=10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y-h*koeff, transform.position.z);
    }
}
