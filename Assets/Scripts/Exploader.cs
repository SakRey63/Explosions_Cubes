using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Exploader : MonoBehaviour
{
    [SerializeField] private int _maxChanceSeparation = 101;
    [SerializeField] private int _chanceSeparation = 100;
    [SerializeField] private int _minChanceSeparation = 0;
    [SerializeField] private float _scaleCube = 3;
    [SerializeField] private int _indexCube = 0;
    [SerializeField] private Vector3 _pointSpawn;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Explosion _explosion;
    
    private void Start()
    {
        _cubeSpawner.SpawnedCubes(_pointSpawn, _indexCube, _scaleCube);
    }

    private void ReduceSizeCube()
    {
        float bisection = 2f;

        _scaleCube = _scaleCube / bisection;
    }
    
    private void OnEnable()
    {
        Cube.InfoCubed += Separation;
    }

    private void OnDisable()
    {
        Cube.InfoCubed -= Separation;
    }
    
    private void Separation(Vector3 point, int index)
    {
        int numberChance = GetRandomNumber(_minChanceSeparation, _maxChanceSeparation);
        
        if (numberChance <= _chanceSeparation)
        {
            _indexCube++;
            
            ReduceSizeCube();
            
            _cubeSpawner.SpawnedCubes(point, _indexCube, _scaleCube);
            
            ReducingChanceDivision();
        }
        else
        {
            _explosion.Explode(point, index);
        }
    }
    
    private void ReducingChanceDivision()
    {
        int bisection = 2;
        
        _chanceSeparation = _chanceSeparation / bisection;
    }

    private int  GetRandomNumber(int minNumber, int maxNumber)
    {
        int random = Random.Range(minNumber, maxNumber);

        return random;
    }
}
