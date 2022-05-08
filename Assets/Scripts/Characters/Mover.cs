using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private bool _isMove = false;
    private float _maxDistance = 3f;
    private float _clampTouch = 0.25f;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Touch.started += ctx => StartMove();
        _playerInput.Player.Touch.canceled += ctx => EndMove();
        _playerInput.Enable();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HorizontalPositioning();
        transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

    public void DisableInput()
    {
        _playerInput.Disable();
    }

    private void HorizontalPositioning()
    {
        if (_isMove == true)
        {
            float mousePositionX = Mouse.current.position.ReadValue().x / Screen.width;
            mousePositionX = Mathf.Clamp(mousePositionX, _clampTouch, 1 - _clampTouch);
            float targetPosition = Mathf.Lerp(_maxDistance, -_maxDistance, mousePositionX);
            transform.position = new Vector3(transform.position.x, transform.position.y, targetPosition);
        }
    }

    private void StartMove()
    {
        _isMove = true;
    }

    private void EndMove()
    {
        _isMove= false;
    }
}
