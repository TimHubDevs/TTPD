using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShifter : MonoBehaviour
{
    public Sprite[] prefs;
    void Start()
    {
        GameObject[] plats = GameObject.FindGameObjectsWithTag("Platform");
        foreach (var item in plats)
        {
            item.GetComponent<SpriteRenderer>().sprite = prefs[Random.Range(0, prefs.Length)];
        }
        GameObject[] platss = GameObject.FindGameObjectsWithTag("Spawned");
        foreach (var item in platss)
        {
            item.GetComponent<SpriteRenderer>().sprite = prefs[Random.Range(0, prefs.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
