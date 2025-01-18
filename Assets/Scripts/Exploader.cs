using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Exploader : MonoBehaviour
{
    [SerializeField] private int _maxChanceSeparation = 101;
    [SerializeField] private int _chanceSeparation = 100;
    [SerializeField] private int _minChanceSeparation = 0;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _scaleCube = 3;
    [SerializeField] private int _indexCube = 0;
    
    public int Index => _indexCube;
    public float Scale => _scaleCube;

    public static event Action<Vector3, int, float> Spawn;

    private void ReduceSizeCube()
    {
        float bisection = 2f;

        _scaleCube = _scaleCube / bisection;
        
        Debug.Log("Размер теперь " + _scaleCube);
    }
    
    private void OnEnable()
    {
        InputSystem.OnHit += Separation;
    }

    private void OnDisable()
    {
        InputSystem.OnHit -= Separation;
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

    private void Separation(Vector3 point, int index)
    {
        
        int numberChance = RandomNumber(_minChanceSeparation, _maxChanceSeparation);
        
        if (numberChance <= _chanceSeparation)
        {
            Debug.Log("Родил " + _chanceSeparation + " " + numberChance);
            
            _indexCube++;
            
            ReduceSizeCube();
            
            Spawn?.Invoke(point, _indexCube, _scaleCube);
            
            ReducingChanceDivision();
        }
        else
        {
            Debug.Log("Взрыввв " + numberChance);
            
            Explode(point, index);
        }
    }
    
    private void ReducingChanceDivision()
    {
        int bisection = 2;
        
        _chanceSeparation = _chanceSeparation / bisection;
        
        Debug.Log("Шанс теперь " + _chanceSeparation);
    }

    private int  RandomNumber(int minNumber, int maxNumber)
    {
        int random = Random.Range(minNumber, maxNumber);

        return random;
    }
}
