using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minLimit;
    [SerializeField] private int _maxLimit;
    [SerializeField] private Transform _point;
    [SerializeField] private Cube _cube;
    [SerializeField] private Exploader _exploader;
    [SerializeField] private ColorChanger _colorChanger;

    private Color _color;

    public static event Action CubeCreated;
    private void OnEnable()
    {
        Exploader.Spawn += SpawnCubes;
    }

    private void OnDisable()
    {
        Exploader.Spawn -= SpawnCubes;
    }

    void Start()
    {
        SpawnCubes(_point.position, _exploader.Index, _exploader.Scale);
    }
    
    private void SpawnCubes(Vector3 point, int index, float scale)
    {
        int cubeCount = RandomNumber(_minLimit, _maxLimit);
        
        for (int i = 0; i < cubeCount; i++)
        {
            Cube newCube = Instantiate(_cube, point, Quaternion.Euler(Vector3.zero));
            
            CubeCreated?.Invoke();

            _color = _colorChanger.Color;
            
            newCube.AssigningParameters(index, scale, _color );

            newCube.transform.parent = null;
        }
    }
    
    private int  RandomNumber(int minNumber, int maxNumber)
    {
        int random = Random.Range(minNumber, maxNumber);

        return random;
    }
}
