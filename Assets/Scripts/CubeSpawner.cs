using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minLimit;
    [SerializeField] private int _maxLimit;
    [SerializeField] private Vector3 _point;
    [SerializeField] private Cube _cube;
    [SerializeField] private Exploader _exploader;
    [SerializeField] private ColorChanger _colorChanger;

    private Vector3 _pointSpawn;
    private Color _color;
    
    private void OnEnable()
    {
        _exploader.Spawn += SpawnCubes;
    }

    private void OnDisable()
    {
        _exploader.Spawn -= SpawnCubes;
    }

    void Start()
    {
        SpawnCubes(_point, _exploader.Index, _exploader.Scale);
    }
    
    private void SpawnCubes(Vector3 point, int index, float scale)
    {
        int cubeCount = RandomNumber(_minLimit, _maxLimit);
        
        for (int i = 0; i < cubeCount; i++)
        {
            Cube newCube = Instantiate(_cube, point, Quaternion.Euler(Vector3.zero));

            _color = _colorChanger.ChoosingColor();
            
            newCube.AssigningParameters(index, scale, _color);

            newCube.transform.parent = null;
        }
    }
    
    private int  RandomNumber(int minNumber, int maxNumber)
    {
        int random = Random.Range(minNumber, maxNumber);

        return random;
    }
}
