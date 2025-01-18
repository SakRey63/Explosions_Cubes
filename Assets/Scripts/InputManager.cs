using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SceneManager _sceneManager;
    
    private Ray _ray;

    public event Action OnHit;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            Physics.Raycast(_ray, out hit, Mathf.Infinity);
    
            if (hit.collider.GetComponent<CubeController>())
            {
                OnHit?.Invoke();
                
                hit.collider.GetComponent<CubeController>().DestroyCube(_sceneManager.Dell);
            }
        }
    }
}
