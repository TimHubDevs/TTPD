﻿using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private Transform _isGroundedChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallMultiplier = 2.5f;
    [SerializeField] private float _lowJumpMultiplier = 2f;
    [SerializeField] private GameObject _headGO;
    [SerializeField] private GameObject _bodyGO;
    [SerializeField] private GameObject _playerGO;

    private short _soundGround = 1;
    FMOD.Studio.EventInstance jumpdwnInstance;
    private float _speed = 5f;
    private bool _isGrounded = false;
    private float _checkGroundRadius = 0.05f;
    private bool _isHiding = false;
    private bool _isReversedGrav;
    private bool _isAttack;

    private void Start()
    {
        _isReversedGrav = false;
    }


    private void OnEnable()
    {
        _playerHealth.painEvent += Pain;
    }

    private void Update()
    {
        Move();
        if (!_isReversedGrav)
        {
            Jump();
            BetterJump();
        }
        else
        {
            JumpG();
            BetterJumpG();
        }

        CheckIfGrounded();

        Hide();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeGravity();
        }
#endif

        Attack();
        HealthChecker();
    }

    private void Pain()
    {
        _playerAnimation.Pain();
    }

    private void HealthChecker()
    {
        if (_playerHealth._currentHealth == 0)
        {
            _playerAnimation.Death();
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(1) && _isGrounded && !_isHiding)
        {
            _isAttack = true;
            _playerAttack.AttackFar();
        }

        if (Input.GetMouseButtonDown(0) && _isGrounded && !_isHiding)
        {
            _isAttack = true;
            _playerAttack.AttackСLose();
        }
    }

    private void ChangeGravity()
    {
        if (_isReversedGrav)
        {
            _isReversedGrav = false;
            GetComponent<Rigidbody2D>().gravityScale *= -1;
            _playerGO.transform.Rotate(new Vector3(0, 180, 180));
        }
        else
        {
            _isReversedGrav = true;
            GetComponent<Rigidbody2D>().gravityScale *= -1;
            _playerGO.transform.Rotate(new Vector3(0, 180, 180));
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        _playerAnimation.Move(x != 0);
        if (x < 0)
        {
            _headGO.GetComponent<SpriteRenderer>().flipX = false;
            _bodyGO.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x > 0)
        {
            _headGO.GetComponent<SpriteRenderer>().flipX = true;
            _bodyGO.GetComponent<SpriteRenderer>().flipX = false;
        }

        float moveBy = x * _speed;
        _rigidbody2D.velocity =
            (!_isHiding && !_isAttack) ? new Vector2(moveBy, _rigidbody2D.velocity.y) : Vector2.zero;
    }

    private void Hide()
    {
        if (Input.GetKeyDown(KeyCode.S) && !_isHiding && _isGrounded)
        {
            _playerAnimation.Hide(true);
            _isHiding = true;
            _rigidbody2D.velocity = Vector2.zero;
        }
        else if (Input.GetKeyDown(KeyCode.S) && _isHiding)
        {
            _playerAnimation.Hide(false);
            StartCoroutine(SetHidingFalse());
        }
    }

    private IEnumerator SetHidingFalse()
    {
        do
        {
            yield return null;
        } while (_playerAnimation.GetStateInfo("UnHide") || _playerAnimation.GetStateInfo("Hide"));

        _isHiding = false;
    }

    private void Jump()
    {
        if (!Input.GetKey(KeyCode.Space) || !_isGrounded || _isHiding) return;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        _playerAnimation.Jump(true);
    }

    private void BetterJump()
    {
        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity * (_fallMultiplier - 1) * Time.deltaTime;
            _playerAnimation.Fall(true);
        }
        else if (_rigidbody2D.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.velocity += Vector2.up * Physics2D.gravity * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void JumpG()
    {
        if (!Input.GetKey(KeyCode.Space) || !_isGrounded || _isHiding) return;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, -_jumpForce);
        _playerAnimation.Jump(true);
    }

    private void BetterJumpG()
    {
        if (_rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.velocity += Vector2.up * -Physics2D.gravity * (_fallMultiplier - 1) * Time.deltaTime;
            _playerAnimation.Fall(true);
        }
        else if (_rigidbody2D.velocity.y < 0 && !Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.velocity += Vector2.up * -Physics2D.gravity * (_lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(_isGroundedChecker.position, _checkGroundRadius, _groundLayer);
        if (collider != null)
        {
            _isGrounded = true;
            _playerAnimation.Jump(false);
            _playerAnimation.Fall(false);
            while (_soundGround <= 1)
            {
                jumpdwnInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/JumpDown");
                jumpdwnInstance.start();
                jumpdwnInstance.release();

                _soundGround++;
            }
        }
        else
        {
            _isGrounded = false;
            _soundGround = 1;
        }
    }

    public void SetAttackStateFalse()
    {
        _isAttack = false;
    }
}