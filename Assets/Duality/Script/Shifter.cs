using UnityEngine;
using System.Collections;
using System;

public class Shifter : MonoBehaviour
{
    [SerializeField] GameObject darkPlayMode;
    [SerializeField] GameObject lightPlayMode;
    [SerializeField] GameObject remains;
    [SerializeField] GameObject shiftScreen;
    bool shifted;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shifted) return;
        shifted = true;
        if (!collision.CompareTag("Player")) return;
        shiftScreen.GetComponent<Animator>().SetBool("shift", true);
        //collision.GetComponent<PlayerController>()._isShifting = true;
    }

    public void Shift()
    {
        darkPlayMode.SetActive(true);
        shiftScreen.GetComponent<ShiftScreen>().GetAdopted();
        lightPlayMode.SetActive(false);
        remains.SetActive(true);
        STATIC.ISBLACK = !STATIC.ISBLACK;
        GetComponent<SpriteRenderer>().enabled = false;
       // Destroy(gameObject,3);
    }
}