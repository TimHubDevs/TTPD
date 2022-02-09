using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _damageAmount;
    [SerializeField] private Health _health;
    [HideInInspector] public GameObject playerGO;

    private void OnEnable()
    {
        _health.painEvent += Pain;
    }

    private void Pain()
    {
        PainAnimation();
    }

    private void PainAnimation()
    {
        _animator.SetTrigger("Pain");
    }

    public void HealthCheck()
    {
        if (_health._currentHealth != 0) return;

        if (gameObject.name == "Bomb_Black(Clone)")
        {
            Attack();
        }

        Death();
    }

    private void Death()
    {
        _animator.SetTrigger("Death");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerGO = other.gameObject;
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerGO = null;
        }
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void DealDamage()
    {
        if (playerGO == null) return;
        if (playerGO.GetComponent<Health>()._currentHealth == 0) return;
        playerGO.GetComponent<Health>().DecreaseHealth(_damageAmount);
    }

    public void KillMob()
    {
        Destroy(gameObject);
    }

    public void CheckIsPlayerInCollider()
    {
        if (playerGO != null)
        {
            Attack();
        }
    }
}