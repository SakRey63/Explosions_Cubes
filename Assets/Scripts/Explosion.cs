using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Exploader _exploader;
    [SerializeField] private float _startEplosionForce;
    [SerializeField] private float _startExplosionRadius;
    [SerializeField] private float _increasingRadius;
    [SerializeField] private float _increasinForceExplosion;
    
    private float _explosionRadius;
    private float _explosionForce;
    
    private void IncreasinForceRadiusExplosion(int indexCube)
    {
        if ( indexCube > 0)
        {
            for (int i = 0; i < indexCube; i++)
            {
                _explosionForce += _increasinForceExplosion;
                _explosionRadius += _increasingRadius;
            }
        }
    }
    
    public void Explode(Vector3 point, int index)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(point, index))
        {
            IncreasinForceRadiusExplosion(index);
            
            explodableObject.AddExplosionForce( _explosionForce, point, _explosionRadius);
        }

        _explosionForce = _startEplosionForce;
        _explosionRadius = _startExplosionRadius;
    }
    
    private List<Rigidbody> GetExplodableObjects(Vector3 point, int index)
    {
        Collider[] hits = Physics.OverlapSphere(point, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        
            if (hit.attachedRigidbody != null && hit.GetComponent<Cube>().Index == index)
            {
                cubes.Add(hit.attachedRigidbody);
            }

        return cubes;
    }
}
