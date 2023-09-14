using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectCheck : MonoBehaviour
{
    public bool isConnected = false;
    public List<GameObject> collidedObjects;

    private void Awake()
    {
        collidedObjects = new List<GameObject>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {            
            collidedObjects.Add(other.gameObject);            
        }
    }

    private void Update()
    {
        if(collidedObjects != null)
        {
            if(isConnected)
            {
                foreach(GameObject go in collidedObjects)
                {
                    go.GetComponent<ConnectCheck>().isConnected = true;
                    collidedObjects.Remove(go);
                }
            }
        }
    }
}
