using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    private Color _color;

    public Color Color => _color;

    private void OnEnable()
    {
        CubeSpawner.CubeCreated += ChoosingColor;
    }

    private void OnDisable()
    {
        CubeSpawner.CubeCreated -= ChoosingColor;
    }

    private void ChoosingColor()
    {       
        _color.r = Random.Range(0f,1f);
        _color.g = Random.Range(0f,1f);
        _color.b = Random.Range(0f,1f);
    }
}
