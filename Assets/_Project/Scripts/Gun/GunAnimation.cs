using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _shootHash = Animator.StringToHash("Shoot");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetShoot()
    {
        _animator.SetTrigger(_shootHash);
    }
}
