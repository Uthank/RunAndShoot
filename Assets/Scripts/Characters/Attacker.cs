using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(LineRenderer))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private AnimationCurve _trajectory;
    [SerializeField] private float _chargeSpeed = 1;
    [SerializeField] private Weapon _defaultWeapon;
    [SerializeField] private GameObject _weaponHolder;
    [SerializeField] private Arrow _arrow;

    private PlayerInput _playerInput;
    private LineRenderer _lineRenderer;
    private Animator _animator;

    private string _chargeAnimation = "Charge";
    private string _shootAnimation = "Shoot";
    private Weapon _currentWeapon;
    private GameObject _instantiatedWeapon;
    private int _trajectoryQuality = 10;
    private IEnumerator _charge;
    private float _chargePower;
    private float _maxChargePower = 30;
    private ArrowType _currentWeaponArrowType;
    private Vector3 _tempPosition;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Touch.started += ctx => StartChargeAttack();
        _playerInput.Player.Touch.canceled += ctx => Shoot();
        _playerInput.Enable();
        _animator = GetComponent<Animator>();
        _currentWeapon = _defaultWeapon;
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void DisableInput()
    {
        _playerInput.Disable();
    }

    public void EnableInput()
    {
        _playerInput.Enable();
    }

    public void ChangeWeapon(Weapon weapon = null)
    {
        if (weapon == null)
            _currentWeapon = _defaultWeapon;
        else
            _currentWeapon = weapon;
    }

    public void ShootTarget(Transform target, Vector3 headOffset)
    {
        if (_instantiatedWeapon == null)
            _instantiatedWeapon = Instantiate(_currentWeapon.Model, _weaponHolder.transform);

        transform.rotation = Quaternion.FromToRotation(Vector3.right, new Vector3(target.position.x, 0, target.position.z) - new Vector3(transform.position.x, 0, transform.position.z));
        _animator.SetTrigger(_shootAnimation);
        Arrow arrow = Instantiate(_arrow, transform.position + transform.rotation * Vector3.right, Quaternion.FromToRotation(Vector3.right, target.position - transform.position).normalized);
        arrow.Initialize(_maxChargePower, _currentWeapon.ArrowType);
    }

    private void StartChargeAttack()
    {
        _instantiatedWeapon = Instantiate(_currentWeapon.Model, _weaponHolder.transform);
        _currentWeaponArrowType = _currentWeapon.ArrowType;

        _animator.SetBool(_chargeAnimation, true);
        _chargePower = 0;

        _charge = Charge(_currentWeapon.DrawedLineColor);
        StartCoroutine(_charge);
    }

    private void Shoot()
    {
        StopCoroutine(_charge);
        _charge = null;
        _lineRenderer.positionCount = 0;
        _animator.SetBool(_chargeAnimation, false);
        Arrow arrow = Instantiate(_arrow, transform.position + Vector3.right, Quaternion.identity);
        arrow.Initialize(_chargePower, _currentWeaponArrowType, _trajectory);
        Destroy(_instantiatedWeapon);
    }

    private void DrawLine(Gradient drawedLineColor)
    {
        _lineRenderer.colorGradient = drawedLineColor;
        Vector3[] positions = new Vector3[_trajectoryQuality + 1];
        Vector3 startPoint = Vector3.up + transform.position;
        positions[0] = startPoint;

        for (int i = 0; i < _trajectoryQuality; i++)
        {
            Vector3 Point = new Vector3(_chargePower / _trajectoryQuality * i, _trajectory.Evaluate((float)(i + 1) / _trajectoryQuality), 0) + transform.position;
            positions[i + 1] = Point;
        }

        _lineRenderer.positionCount = positions.Length;
        _lineRenderer.SetPositions(positions);
    }

    private IEnumerator Charge(Gradient drawedLineColor)
    {
        while (_chargePower < _maxChargePower)
        {
            _chargePower += Time.deltaTime * _chargeSpeed;
            DrawLine(drawedLineColor);
            yield return null;
        }

        while (true)
        {
            DrawLine(drawedLineColor);
            yield return null;
        }
    }
}
