using System.Collections;
using UnityEngine;

public class Frozen : MonoBehaviour
{
    [SerializeField] float _stayDuration = 1;
    [SerializeField] float _fracturedDuration = 3;
    [SerializeField] Rigidbody[] _rigidbodys;

    private void Awake()
    {
        StartCoroutine(FractureOnDelay());
    }

    private IEnumerator FractureOnDelay()
    {
        yield return new WaitForSeconds(_stayDuration);

        foreach (var rigidbody in _rigidbodys)
        {
            rigidbody.isKinematic = false;
        }

        Destroy(gameObject, _fracturedDuration);
    }
}
