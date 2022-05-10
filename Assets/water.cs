using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.5f;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        float offset = Time.time * _scrollSpeed;
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));
    }
}
