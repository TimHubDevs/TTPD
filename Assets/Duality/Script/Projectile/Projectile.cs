using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidbodyProjectile;
    [SerializeField] private float _speed = 0;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        var moveBy = 1 * _speed;
        _rigidbodyProjectile.velocity = new Vector2(moveBy, _rigidbodyProjectile.velocity.y);
    }

    public void Setup()
    {
        // animator.SetBool("isJumping", true);
    }
}