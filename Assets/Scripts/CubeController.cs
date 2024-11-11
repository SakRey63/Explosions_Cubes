using UnityEngine;
using Random = UnityEngine.Random;

public class CubeController : MonoBehaviour
{
    private Renderer _renderer;
    private Color _color;

    private void Start()
    {
        ChoosingColor();
    }

    private void ChoosingColor()
    {
        _renderer = GetComponent<Renderer>();
                
        _color.r = Random.Range(0f,1f);
        _color.g = Random.Range(0f,1f);
        _color.b = Random.Range(0f,1f);
                
        _renderer.material.color = _color;
    }
}
