using UnityEngine;

public class BombMob : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damageAmount;
    [SerializeField] private Health _health;
    private GameObject playerGO;

    private void OnEnable()
    {
        _health.painEvent += Pain;
    }

    private void Pain()
    {
        //pain animation
        PainAnimation();
        HealthChecker();
    }

    private void PainAnimation()
    {
        _animator.SetTrigger("Pain");
    }

    private void HealthChecker()
    {
        if (_health._currentHealth == 0)
        {
            Death();
        }
    }

    private void Death()
    {
        _animator.SetBool("isAttack", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerGO = other.gameObject;
            Death();
        }
    }

    public void DealDamage()
    {
        if (playerGO == null) return;
        playerGO.GetComponent<Health>().DecreaseHealth(_damageAmount);
    }

    public void KillMob()
    {
        Destroy(gameObject);
    }
}
