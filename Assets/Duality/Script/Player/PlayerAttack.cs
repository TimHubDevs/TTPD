using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _rootProjectilePosition;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private PlayerAnimation _playerAnimation;

    public void AttackFar()
    {
        _playerAnimation.AttackFar();
    }

    public void CreateProjectile()
    {
        var projectile = Instantiate(_projectilePrefab, new Vector3(_rootProjectilePosition.position.x +0.35f, _rootProjectilePosition.position.y, _rootProjectilePosition.position.z), Quaternion.identity);
    }

    public void AttackСLose()
    {
        _playerAnimation.AttackClose();
    }
}
