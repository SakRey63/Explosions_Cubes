using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Exploader _exploader;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private void OnEnable()
    {
        _exploader.Explosion += Explode;
    }

    private void OnDisable()
    {
        _exploader.Explosion -= Explode;
    }
    
    private void Explode(Vector3 point, int index)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(point, index))
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
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
