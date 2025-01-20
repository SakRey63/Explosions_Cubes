using System;
using UnityEngine;

public class Cube : MonoBehaviour
{ 
    [SerializeField] private float _scaleCube;
    [SerializeField] private int _index;
    
   
    private Color _color;
    private Renderer _renderer;
    
    public int Index => _index;
    
    public static event Action <Vector3, int> InfoCubed; 

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _renderer.material.color = _color;
        
        transform.localScale = new Vector3(_scaleCube, _scaleCube, _scaleCube);
    }
    
    public void DestroyCube()
    {
        InfoCubed?.Invoke(transform.position, _index);
        
        Destroy(gameObject);
    }

    public void AssigningParameters(int number, float scale, Color color)
    {
        _index = number;
        _scaleCube = scale;
        _color = color;
    }
}
