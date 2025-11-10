using UnityEngine;

public class Flipper : MonoBehaviour
{
    public bool IsFacingRight { get; private set; } = true;

    public void FlipToDirection(float inputValue)
    {
        if (inputValue > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (inputValue < 0 && IsFacingRight)
        {
            Flip();
        }
    }

    public void Flip()
    {
        int rotationAngle = 180;

        IsFacingRight = !IsFacingRight;
        transform.Rotate(0, rotationAngle, 0);
    }
}
