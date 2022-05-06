using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
public class Attacker : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _animator;
    private string _ChargeAnimation = "Charge";

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Touch.started += ctx => StartChargeAttack();
        _playerInput.Player.Touch.canceled += ctx => Shoot();
        _playerInput.Enable();
        _animator = GetComponent<Animator>();
    }

    private void StartChargeAttack()
    {
        _animator.SetBool(_ChargeAnimation, true);
    }

    private void Shoot()
    {
        _animator.SetBool(_ChargeAnimation, false);
    }
}
