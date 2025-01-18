using UnityEngine;

public class Cube : MonoBehaviour
{ 
    [SerializeField] private float _scaleCube;
    [SerializeField] private int _index;
    
    private Color _color;
    private Renderer _renderer;
    
    public int Index => _index;
    
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        
        _renderer.material.color = _color;
        
        gameObject.transform.localScale = new Vector3(_scaleCube, _scaleCube, _scaleCube);
    }

    public void DestroyCube()
    {
        Destroy(gameObject);
    }

    public void AssigningParameters(int number, float scale, Color color)
    {
        _index = number;
        _scaleCube = scale;
        _color = color;
    }
}
