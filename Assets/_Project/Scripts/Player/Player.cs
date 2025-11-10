using UnityEngine;

[RequireComponent(typeof(PlayerAnimation), typeof(PlayerMovement))]
public class Player : BaseCharacter
{
    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();

        CurrentHealth = MaxHealth;

        HealthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        _playerAnimation.SetSpeed(_playerMovement.CurrentSpeedMagnitude);
    }
}
