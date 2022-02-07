using UnityEngine;

public class StaffAttacker : MonoBehaviour
{
    [SerializeField] private float _damageAmount = 25f;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("POOF");
            if (other.gameObject.GetComponent<Health>() == null)
            {
                Debug.LogError($"This {other.gameObject.name} doesn't have Health script!");
                return;
            }

            if (other.gameObject.GetComponent<Health>()._currentHealth == 0) return;

            other.gameObject.GetComponent<Health>().DecreaseHealth(_damageAmount);
        }
    }
}