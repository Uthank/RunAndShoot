using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TapMesage : MonoBehaviour
{
    [SerializeField] AnimationCurve _scaleCurve;
    [SerializeField] float _speed;

    private TMP_Text _text;
    private float _scale;
    private float _time;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _time = 0;
    }

    private void OnEnable()
    {
        _text.enabled = true;
    }

    private void Update()
    {
        _time += Time.deltaTime * _speed;
        _scale = _scaleCurve.Evaluate(_time % 1);
        transform.localScale = Vector3.one * _scale;
    }
}
