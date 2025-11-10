using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Flipper))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private float _deadZoneThreshold = 0.2f;

    private Flipper _flipper;

    public Rigidbody2D Rigidbody2D { get; private set; }

    public float CurrentSpeedMagnitude => Rigidbody2D.velocity.magnitude;

    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _flipper = GetComponent<Flipper>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        if (Mathf.Abs(horizontalInput) >= _deadZoneThreshold || Mathf.Abs(verticalInput) >= _deadZoneThreshold)
        {
            Rigidbody2D.velocity = new Vector2(horizontalInput * _speed, verticalInput * _speed);
        }
        else
        {
            Rigidbody2D.velocity = Vector2.zero;
        }

        _flipper.FlipToDirection(horizontalInput);
    }
}
