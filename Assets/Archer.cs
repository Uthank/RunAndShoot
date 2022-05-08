using System.Collections;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    private Rigidbody _rigidbody;

    private float _epsylon = .3f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public IEnumerator MoveThroughtPositions(Vector3[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Vector3 pos = positions[i];
            
            while ((pos - transform.position).magnitude > _epsylon)
            {
                _rigidbody.velocity = (pos - transform.position).normalized * _speed;
                yield return null;
            }

            Debug.Log(pos + " " + gameObject.name);
        }
    }

}
