using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private Ray _ray;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            Physics.Raycast(_ray, out hit, Mathf.Infinity);
    
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                cube.DestroyCube();
            }
        }
    }
}

