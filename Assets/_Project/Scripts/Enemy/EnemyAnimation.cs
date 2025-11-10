using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _isAttackingHash = Animator.StringToHash("IsAttacking");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIsAttacking(bool isAttacking)
    {
        _animator.SetBool(_isAttackingHash, isAttacking);
    }
}
