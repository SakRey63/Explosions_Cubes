using UnityEngine;
using Random = UnityEngine.Random;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _minLimit;
    [SerializeField] private int _maxLimit;
    [SerializeField] private int _chanceSeparation = 100;

    private void Start()
    {
        SpawnCubes();
    }

    private void SpawnCubes()
    {
        int random = Random.Range(_minLimit, _maxLimit);
        
        for (int i = 0; i < random; i++)
        {
            Instantiate(_cube, _points[Random.Range(0, _points.Length-1)]);
        }
    }
}
