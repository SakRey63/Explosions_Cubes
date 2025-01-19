using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChanger : MonoBehaviour
{
    private Color _colorCube;

    public Color ChoosingColor()
    {
        _colorCube.r = Random.Range(0f,1f);
        _colorCube.g = Random.Range(0f,1f);
        _colorCube.b = Random.Range(0f,1f);

        return _colorCube;
    }
}
