using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftScreen : MonoBehaviour
{
    [SerializeField] Shifter shifter;
    [SerializeField] GameObject bg;

    public void GetAdopted()
    {
        transform.SetParent(bg.transform);
        transform.localPosition = Vector3.zero;
    }
    public void Shift()
    {
        shifter.Shift();
    }
}
