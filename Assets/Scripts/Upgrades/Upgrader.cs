using UnityEngine;
using TMPro;

public class Upgrader : MonoBehaviour
{
    [SerializeField] TMP_Text _textField;

    private UpgradeGoodness _upgradeGoodness;
    private UpgradeTypes _upgradeType;
    private int _value;
    private string _text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Crowd>(out Crowd crowd))
        {
            crowd.CreateAllies(_upgradeType, _value);
        }
    }

    public void Initialize(UpgradeGoodness upgradeGoodness, UpgradeTypes upgradeTypes, int value)
    {
        _upgradeGoodness = upgradeGoodness;
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

        _text = _text + _value;
        _textField.text = _text;
    }
}
