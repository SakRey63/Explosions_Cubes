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
    [SerializeField] private Raycaster _raycaster;
    public int Index => _indexCube;
    public float Scale => _scaleCube;

    public event Action<Vector3, int, float> Spawned;
    public event Action<Vector3, int> Explosion;

    private void ReduceSizeCube()
    {
        float bisection = 2f;

        _scaleCube = _scaleCube / bisection;
    }
    
    private void OnEnable()
    {
        _raycaster.PositionCube += Separation;
    }

    private void OnDisable()
    {
        _raycaster.PositionCube -= Separation;
    }
    
    private void Separation(Vector3 point, int index)
    {
        int numberChance = RandomNumber(_minChanceSeparation, _maxChanceSeparation);
        
        if (numberChance <= _chanceSeparation)
        {
            _indexCube++;
            
            ReduceSizeCube();
            
            Spawned?.Invoke(point, _indexCube, _scaleCube);
            
            ReducingChanceDivision();
        }
        else
        {
            Explosion?.Invoke(point, index);
        }
    }
    
    private void ReducingChanceDivision()
    {
        int bisection = 2;
        
        _chanceSeparation = _chanceSeparation / bisection;
    }

    private int  RandomNumber(int minNumber, int maxNumber)
    {
        int random = Random.Range(minNumber, maxNumber);

        return random;
    }
}
