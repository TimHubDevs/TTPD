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
        var projectile = Instantiate(_projectilePrefab, new Vector3(_rootProjectilePosition.position.x +0.7f, _rootProjectilePosition.position.y, _rootProjectilePosition.position.z), Quaternion.identity);
    }

    public void AttackСLose()
    {
        _playerAnimation.AttackClose();
        // var projectile = Instantiate(_projectilePrefab, Vector3.zero, Quaternion.identity, _rootProjectileSpawn);
        // projectile.transform.localPosition = new Vector3(0.3f, 0f, 0f);
    }
}
