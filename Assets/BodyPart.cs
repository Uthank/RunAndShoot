using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] Character _character;

    public Character Character => _character;
}
