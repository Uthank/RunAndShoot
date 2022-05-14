using System.Collections;
using UnityEngine;

public class Frozen : MonoBehaviour
{
    [SerializeField] float _fracturedDuration = 3;
    [SerializeField] Rigidbody[] _rigidbodys;

    private void Awake()
    {
        foreach (var rigidbody in _rigidbodys)
        {
            rigidbody.isKinematic = false;
        }

        Destroy(gameObject, _fracturedDuration);
    }
}
