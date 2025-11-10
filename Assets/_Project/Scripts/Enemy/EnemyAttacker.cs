using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _attackRate = 2f;

    private Coroutine _attackCoroutine;
    private IDamageable _currentTarget;

    public bool IsAttacking { get; private set; } = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable target))
        {
            if (_currentTarget == target) return;

            StopAttackCoroutine();

            _currentTarget = target;
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable target) && target == _currentTarget)
        {
            StopAttackCoroutine();
            _currentTarget = null;
        }
    }

    private IEnumerator AttackCoroutine()
    {
        var waitForSeconds = new WaitForSeconds(_attackRate);

        IsAttacking = true;

        while (_currentTarget != null)
        {
            _currentTarget.TakeDamage(_damage);
            yield return waitForSeconds;
        }

        IsAttacking = false;
    }

    private void StopAttackCoroutine()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }

        IsAttacking = false;
    }
}
