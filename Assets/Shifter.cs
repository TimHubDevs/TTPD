using UnityEngine;

public class Shifter : MonoBehaviour
{
    // [SerializeField] private GameObject _lightGO, _darkGO;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        // _lightGO.SetActive(false);
        // _darkGO.SetActive(true);
        //Shift
        STATIC.ISBLACK = !STATIC.ISBLACK;
        Destroy(gameObject);
    }
}