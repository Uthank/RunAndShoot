using TMPro;
using UnityEngine;

public class BossHealthText : MonoBehaviour
{
    [SerializeField] Boss _boss;
    [SerializeField] TMP_Text text;

    private void OnEnable()
    {
        _boss.OnHealthChanged += ChangeText;
    }

    private void OnDisable()
    {
        _boss.OnHealthChanged -= ChangeText;
    }

    private void ChangeText(int health)
    {
        text.text = health.ToString();
    }
}
