using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private AnimationCurve _trajectory;
    [SerializeField] private float _chargeSpeed = 1;
    [SerializeField] private Weapon _defaultWeapon;
    [SerializeField] private GameObject _weaponHolder;
    [SerializeField] private Arrow _arrow;

    private PlayerInput _playerInput;
    private Animator _animator;
    private string _ChargeAnimation = "Charge";
    private float _chargePower;
    private Weapon _currentWeapon;
    private GameObject _instantiatedWeapon;
    private int _trajectoryQuality = 10;
    private IEnumerator _charge;
    private LineRenderer _lineRenderer;


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

    private void OnDestroy()
    {
        _playerInput.Disable();
    }

    private void StartChargeAttack()
    {
        _instantiatedWeapon = Instantiate(_currentWeapon.Model, _weaponHolder.transform);

        _animator.SetBool(_ChargeAnimation, true);
        _chargePower = 3;

        _charge = Charge();
        StartCoroutine(_charge);
    }

    private void Shoot()
    {
        StopCoroutine(_charge);
        _charge = null;
        _lineRenderer.positionCount = 0;
        _animator.SetBool(_ChargeAnimation, false);
        Arrow arrow = Instantiate(_arrow, transform.position + Vector3.right, Quaternion.identity);
        arrow.Initialize(_trajectory, _chargePower, _currentWeapon.ArrowType);
        Destroy(_instantiatedWeapon);
    }

    private void DrawLine()
    {
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

    private IEnumerator Charge()
    {
        while (_chargePower < 30)
        {
            _chargePower += Time.deltaTime * _chargeSpeed;
            DrawLine();
            yield return null;
        }

        while (true)
        {
            DrawLine();
            yield return null;
        }
    }
}
