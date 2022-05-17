using UnityEngine;
using TMPro;

public class Upgrader : MonoBehaviour
{
    [SerializeField] TMP_Text _textField;
    [SerializeField] Material _materialGood;
    [SerializeField] Material _materialBad;

    private UpgradeTypes _upgradeType;
    private int _value;
    private string _text;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crowd>(out Crowd crowd))
        {
            crowd.CreateAllies(_upgradeType, _value);
        }
    }

    public void Initialize(UpgradeGoodness upgradeGoodness, UpgradeTypes upgradeTypes, int value)
    {
        _upgradeType = upgradeTypes;
        _value = value;

        switch (_upgradeType)
        {
            case UpgradeTypes.Additive:
                _text = "+";
                break;
            case UpgradeTypes.Multiplicate:
                _text = "x";
                break;
        }

        _text += _value;
        _textField.text = _text;

        switch (upgradeGoodness)
        {
            case UpgradeGoodness.Good:
                _renderer.material = _materialGood;
                break;
            case UpgradeGoodness.Bad:
                _renderer.material = _materialBad;
                break;
        }
    }
}
