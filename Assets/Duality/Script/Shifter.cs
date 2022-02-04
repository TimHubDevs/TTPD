using UnityEngine;

public class Shifter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        //Shift
        STATIC.ISBLACK = !STATIC.ISBLACK;
        Destroy(gameObject);
    }
}