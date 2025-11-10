using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private int _damage = 1;

    private Rigidbody2D _rigidbody2D;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }

    public void Launch(Vector2 direction)
    {
        _rigidbody2D.velocity = direction.normalized * _speed;
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        float lifeTime = 5f;

        Destroy(gameObject, lifeTime);
    }
}

