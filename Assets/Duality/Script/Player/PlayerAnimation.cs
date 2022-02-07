using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] public Animator _animator;

    public void Hide(bool isHide)
    {
        _animator.SetBool("isHiding", isHide);
    }

    public void Jump(bool isJumping)
    {
        _animator.SetBool("isJumping", isJumping);
    }

    public void Fall(bool isFalling)
    {
        _animator.SetBool("isFalling", isFalling);
    }

    public void Move(bool isMoving)
    {
        _animator.SetBool("isMoving", isMoving);
    }

    public void AttackClose()
    {
        _animator.SetTrigger("AttackClose");
    }

    public void AttackFar()
    {
        _animator.SetTrigger("AttackFar");
    }
    public void Pain()
    {
        _animator.SetTrigger("Pain");
    }
    public void Death()
    {
        _animator.SetTrigger("Death");
    }

    public bool GetStateInfo(string nameState)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(nameState);
    }
}