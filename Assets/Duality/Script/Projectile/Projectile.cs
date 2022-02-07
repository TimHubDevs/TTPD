using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbodyProjectile;
    private float _speed = 0;
    [SerializeField] private float _damageAmount = 25f;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        var moveBy = 1 * _speed;
        _rigidbodyProjectile.velocity = new Vector2(moveBy, _rigidbodyProjectile.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("PAM");
            other.gameObject.GetComponent<Health>().DecreaseHealth(_damageAmount);
            _rigidbodyProjectile.gravityScale = 0;
            _animator.SetTrigger("isBoom");
        }
    }

    public void KillProjectile()
    {
        Destroy(gameObject);
    }
}