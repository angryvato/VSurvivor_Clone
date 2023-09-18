using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _mapTrigger : MonoBehaviour
{
    _MapController _mapController;
    public GameObject targetMap;

    private void Start()
    {
        _mapController = FindObjectOfType<_MapController>();
        targetMap = this.transform.parent.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Name of trigger parent is: " + targetMap.name);
            _mapController.currentMap = targetMap;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(_mapController.currentMap == targetMap)
            {
                _mapController.currentMap = null;
            }
        }
    }
}
