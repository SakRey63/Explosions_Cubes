using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Exploader _exploader;
    
    private Ray _ray;
    
    public event Action<Vector3> PositionCube; 
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            Physics.Raycast(_ray, out hit, Mathf.Infinity);
    
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                Cube hitCube = hit.collider.GetComponent<Cube>();

                PositionCube?.Invoke(hitCube.transform.position);
                
                hitCube.DestroyCube(_exploader.OnExplosion);
            }
        }
    }
}

