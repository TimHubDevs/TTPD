using UnityEngine;

public class StaffAttacker : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 25f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("POOF");
            if (other == null) return;
            other.gameObject.GetComponent<Health>().DecreaseHealth(_damageAmount);
        }
    }
}
