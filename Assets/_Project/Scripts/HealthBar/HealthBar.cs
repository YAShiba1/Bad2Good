using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        _slider.maxValue = maxHealth;

        SetHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        _slider.value = health;
    }
}
