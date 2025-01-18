using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private Ray _ray;

    public static event Action<Vector3, int> OnHit;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            
            Physics.Raycast(_ray, out hit, Mathf.Infinity);
    
            if (hit.collider.GetComponent<Cube>())
            {
                Vector3 point = hit.collider.transform.position;
                
                int index = hit.collider.GetComponent<Cube>().Index;
                
                Debug.Log(index);
                
                OnHit?.Invoke(point, index);
                
                hit.collider.GetComponent<Cube>().DestroyCube();
            }
        }
    }
}

