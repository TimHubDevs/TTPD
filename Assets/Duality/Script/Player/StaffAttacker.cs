using UnityEngine;

public class StaffAttacker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        //example
        if (other.name == "Enemy")
        {
            other.gameObject.GetComponent<Health>().DecreaseHealth(25f);
        }
    }
    
}
