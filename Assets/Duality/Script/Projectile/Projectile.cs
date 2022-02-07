using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbodyProjectile;
    private float _speed = 0;
    [SerializeField] private float _damageAmount = 25f;
    Vector3 shootDirection;
    public void SetSpeed(float speed)
    {
        if (_speed == 0)
        {
            Destroy(gameObject, 1);
            _speed = speed;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - transform.position;
            shootDirection = shootDirection.normalized;
        }
    }

    private void Update()
    {
        var moveBy = 1 * _speed;
        _rigidbodyProjectile.velocity = new Vector2(shootDirection.x * moveBy, shootDirection.y * moveBy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Projectile collided with Enemy");
            other.gameObject.GetComponent<Health>().DecreaseHealth(_damageAmount);
            _rigidbodyProjectile.gravityScale = 0;
            _animator.SetTrigger("isBoom");
        }
        else if (other.tag == "Platform")
        {
            KillProjectile();
        }
    }

    public void KillProjectile()
    {
        Destroy(gameObject);
    }
}