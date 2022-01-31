using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shifter : MonoBehaviour
{
    public GameObject light, dark;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            light.SetActive(false);
            dark.SetActive(true);
            //Shift
            if (STATIC.ISBLACK)
                STATIC.ISBLACK = false;
            else
                STATIC.ISBLACK = true;
            Destroy(gameObject);
        }
    }
}
