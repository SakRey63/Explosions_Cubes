using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{ 
    [SerializeField] private float _scaleCube;
    [SerializeField] private int _index;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
   
    private Color _color;
    private Renderer _renderer;
    
    public int Index => _index;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        _renderer.material.color = _color;
        
        transform.localScale = new Vector3(_scaleCube, _scaleCube, _scaleCube);
    }
    
    private void Explode(Vector3 point)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(point))
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 point)
    {
        Collider[] hits = Physics.OverlapSphere(point, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        
            if (hit.attachedRigidbody != null && hit.GetComponent<Cube>().Index == _index)
            {
                cubes.Add(hit.attachedRigidbody);
            }

        return cubes;
    }
    
    public void DestroyCube(bool onExplosion)
    {
        if (onExplosion)
        {
             Destroy(gameObject);
        }
        else
        {
            Explode(transform.position);
            
            Destroy(gameObject);
        }
    }

    public void AssigningParameters(int number, float scale, Color color)
    {
        _index = number;
        _scaleCube = scale;
        _color = color;
    }
}
