using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sphere : MonoBehaviour
{
    private Vector3 worldPosition;
    private Vector3 _mousePosition;
    public LayerMask mask;    


    private void Update()
    {
        _mousePosition = Mouse.current.position.ReadValue();
        MoveSphere();
    }

    private void MoveSphere()
    {
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, mask))
        {
            worldPosition = hit.point;
        }

        transform.position = worldPosition;
    }
}
