using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    public List<GameObject> propSpawnPoint;
    public List<GameObject> propPrefabs; 

    private void Start()
    {
        SpawnProps();
    }

    void SpawnProps()
    {
        foreach (GameObject prop in propSpawnPoint)
        {
            int rand = Random.Range(0, propPrefabs.Count);
            GameObject goProp = Instantiate(propPrefabs[rand], prop.transform.position, Quaternion.identity);
            goProp.transform.parent = prop.transform;
        }
    }
}
