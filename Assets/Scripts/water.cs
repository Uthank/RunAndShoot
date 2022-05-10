using UnityEngine;

[RequireComponent(typeof(Renderer))]
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
