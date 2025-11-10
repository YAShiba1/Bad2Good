using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Transform PlayerPosition { get; private set; }

    public bool Detected { get; private set; }  = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerPosition = player.transform;

            Detected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerPosition = null;

            Detected = false;
        }
    }
}
