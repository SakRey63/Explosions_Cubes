using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeController : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private float _scaleCube;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    
    private Renderer _renderer;
    private Color _color;
    
    public int Index => _index;

    private void Start()
    {
        ChoosingColor();

        gameObject.transform.localScale = new Vector3(_scaleCube, _scaleCube, _scaleCube);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        
            if (hit.attachedRigidbody != null && hit.GetComponent<CubeController>().Index == _index)
            {
                cubes.Add(hit.attachedRigidbody);
            }

        return cubes;
    }

    private void ChoosingColor()
    {
        _renderer = GetComponent<Renderer>();
               
        _color.r = Random.Range(0f,1f);
        _color.g = Random.Range(0f,1f);
        _color.b = Random.Range(0f,1f);
        
        _renderer.material.color = _color;
    }

    public void DestroyCube(bool del)
    {
        if (del)
        {
            Destroy(gameObject);
        }
        else
        {
            Explode();
            
            Destroy(gameObject);
        }
    }

    public void AssigningParameters(int number, float scale)
    {
        _index = number;
        _scaleCube = scale;
    }
}
