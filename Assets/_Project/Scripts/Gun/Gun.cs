using UnityEngine;

[RequireComponent(typeof(GunAnimation))]
public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _shootingPosition;
    [SerializeField] private Bullet _bullet;

    private GunAnimation _animation;

    private void Awake()
    {
        _animation = GetComponent<GunAnimation>();
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(_bullet, _shootingPosition.position, _shootingPosition.rotation);

        bullet.Launch(transform.right);

        _animation.SetShoot();
    }
}
