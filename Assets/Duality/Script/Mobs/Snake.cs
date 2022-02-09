using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _range = 1f;
    [SerializeField] private SpriteRenderer _body;
    private GameObject _player;
    private float _speed = 5f;

    private void Start()
    {
        _player = GameObject.Find("Light_PlayMode");
    }

    private void Update()
    {
        if (_player == null) return;

        float distance = Vector3.Distance(transform.position, _player.transform.position);
        bool tooClose = distance < _range && _player.transform.position.y - transform.position.y < 1;
        
        if (tooClose)
        {
            _enemy.Attack();
            if (_enemy.playerGO != null)
            {
                return;
            }

            var relativePoint = transform.InverseTransformPoint(_player.transform.position);
            _body.flipX = relativePoint.x < 0.0 ? true : false;
            _rigidbody2D.velocity = relativePoint.x < 0.0
                ? new Vector2(-1 * _speed, _rigidbody2D.velocity.y)
                : new Vector2(1 * _speed, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = Vector2.zero;
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}