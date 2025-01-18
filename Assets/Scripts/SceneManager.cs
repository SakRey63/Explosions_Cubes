using UnityEngine;
using Random = UnityEngine.Random;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _minLimit;
    [SerializeField] private int _maxLimit;
    [SerializeField] private int _maxChanceSeparation = 101;
    [SerializeField] private int _chanceSeparation = 100;
    [SerializeField] private int _minChanceSeparation = 0;
    [SerializeField] private CubeController _controller;
    [SerializeField] private InputManager _inputManager;
    
    private float _scaleCube = 3f;
    private int _indexCube = 0;
    private bool _onDel;

    public bool Dell => _onDel;
    
    private void OnEnable()
    {
        _inputManager.OnHit += Separation;
        
    }

    private void OnDisable()
    {
        _inputManager.OnHit -= Separation;
    }
    
    private void Start()
    {
        SpawnCubes();
    }

    private void ReduceSizeCube()
    {
        float bisection = 2f;

        _scaleCube = _scaleCube / bisection;
    }

    private void Separation()
    {
        int numberChance = RandomNumber(_minChanceSeparation, _maxChanceSeparation);
        
        if (numberChance <= _chanceSeparation)
        {
            _onDel = true;
            
            SpawnCubes();
            
            ReducingChanceDivision();
        }
        else
        {
            _onDel = false;
        }
    }
    
    private void ReducingChanceDivision()
    {
        int bisection = 2;
        
        _chanceSeparation = _chanceSeparation / bisection;
    }
    
    private void SpawnCubes()
    {
        _indexCube++;
        
        int cubeCount = RandomNumber(_minLimit, _maxLimit);
        
        for (int i = 0; i < cubeCount; i++)
        {
            Instantiate(MakeChangesCube(_cube), _point);

            _point.parent = null;
        }
        
        ReduceSizeCube();
    }

    private GameObject MakeChangesCube(GameObject cube)
    {
        _controller = cube.GetComponent<CubeController>();
            
        _controller.AssigningParameters(_indexCube, _scaleCube);

        return cube;
    }

    private int  RandomNumber(int minNumber, int maxNumber)
    {
        int random = Random.Range(minNumber, maxNumber);

        return random;
    }
}
