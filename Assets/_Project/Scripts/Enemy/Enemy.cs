using UnityEngine;

[RequireComponent(typeof(PlayerDetector), typeof(EnemyMover), typeof(PatrolArea))]
[RequireComponent(typeof(EnemyAnimation), typeof(EnemyAttacker))]
public class Enemy : BaseCharacter
{
    private EnemyAttacker _attacker;
    private PlayerDetector _playerDetection;
    private EnemyMover _enemyMovement;
    private PatrolArea _patrolArea;
    private EnemyAnimation _animation;

    private void Start()
    {
        _playerDetection = GetComponent<PlayerDetector>();
        _enemyMovement = GetComponent<EnemyMover>();
        _patrolArea = GetComponent<PatrolArea>();
        _animation = GetComponent<EnemyAnimation>();
        _attacker = GetComponent<EnemyAttacker>();

        CurrentHealth = MaxHealth;
        HealthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        if(_attacker.IsAttacking == false)
        {
            if (_playerDetection.Detected)
            {
                ChasePlayer();
            }
            else
            {
                _patrolArea.Patrol();
            }
        }

        _animation.SetIsAttacking(_attacker.IsAttacking);
    }

    private void ChasePlayer()
    {
        _enemyMovement.MoveTowards(_playerDetection.PlayerPosition);
    }
}
