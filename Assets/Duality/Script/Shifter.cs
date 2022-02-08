using UnityEngine;

public class Shifter : MonoBehaviour
{
    [SerializeField] GameObject darkPlayMode;
    [SerializeField] GameObject lightPlayMode;
    [SerializeField] GameObject remains;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        lightPlayMode.SetActive(false);
        darkPlayMode.SetActive(true);
        remains.SetActive(true);
        STATIC.ISBLACK = !STATIC.ISBLACK;
        Destroy(gameObject);
    }
}