using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private int _speedHash = Animator.StringToHash("Speed");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(_speedHash, Mathf.Abs(speed));
    }
}