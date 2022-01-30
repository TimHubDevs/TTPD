using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float _speed = 0;

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        var moveBy = 1 * _speed;
        rigidbody.velocity = new Vector2(moveBy, rigidbody.velocity.y);
    }
}