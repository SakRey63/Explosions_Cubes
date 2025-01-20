using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minLimit;
    [SerializeField] private int _maxLimit;
    [SerializeField] private Cube _cube;

    private Vector3 _pointSpawn;
    private Color _color;
    
    public void SpawnedCubes(Vector3 point, int index, float scale)
    {
        int cubeCount = GetRandomNumber(_minLimit, _maxLimit);
        
        for (int i = 0; i < cubeCount; i++)
        {
            Cube newCube = Instantiate(_cube, point, Quaternion.Euler(Vector3.zero));

            TryGetComponent(out ColorChanger color);

            _color = color.ChoosingColor();
            
            newCube.AssigningParameters(index, scale, _color);

            newCube.transform.parent = null;
        }
    }
    
    private int  GetRandomNumber(int minNumber, int maxNumber)
    {
        int random = Random.Range(minNumber, maxNumber);

        return random;
    }
}
