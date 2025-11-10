using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private Vector3 _defaultScale;

    private void Awake()
    {
        _defaultScale = transform.localScale;
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            return;
        }

        float angle = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;
        Quaternion lookRotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = lookRotation;

        if (_joystick.Horizontal > 0)
        {
            transform.localScale = _defaultScale;
        }
        else
        {
            transform.localScale = new Vector3(_defaultScale.x, -_defaultScale.y, -_defaultScale.z);
        }
    }
}
