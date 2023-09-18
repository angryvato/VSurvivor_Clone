using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckandSpawnMap : MonoBehaviour
{
    public List<GameObject> MapChunks;
    public GameObject player;
    public string tagText;
    GameObject newMap = null;
    Transform mapPointTransform;
    GameObject gameObjectCol = null;
    public LayerMask layerMask;
    public List<GameObject> collidedObjects;
    GameObject instGameObject;

    public int counter = 0;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        collidedObjects = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {    
            collidedObjects.Add(other.gameObject);            
            
            gameObjectCol = other.gameObject;
            mapPointTransform = other.transform;
            tagText = other.gameObject.tag;
            CheckAndLoop();
        }
    }           
    
    private void OnTriggerExit(Collider other)
    {        
        collidedObjects.Remove(other.gameObject);
    }

    private void CheckAndLoop()
    {
        foreach (GameObject obj in collidedObjects)
        {
            gameObjectCol = obj.gameObject;
            mapPointTransform = obj.transform;
            tagText = obj.gameObject.tag;
            if(gameObjectCol.activeSelf)
            {
                SpawnMap();
            }
        }
    }     

    void SpawnMap()
    {
        int rand = UnityEngine.Random.Range(0, MapChunks.Count);

        switch (tagText)
        {
            case "Right":                
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(-25, 0, 0), Quaternion.identity);
                instGameObject = newMap.transform.Find("Left").gameObject;
                instGameObject.SetActive(false);
               // collidedObjects.Clear();
                break;
            case "Left":
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(25, 0, 0), Quaternion.identity);
                instGameObject = newMap.transform.Find("Right").gameObject;
                instGameObject.SetActive(false);
               //  collidedObjects.Clear();
                break;
            case "Top":
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(0, 0, -25), Quaternion.identity);
                instGameObject = newMap.transform.Find("Bottom").gameObject;
                instGameObject.SetActive(false);
              //   collidedObjects.Clear();
                break;
            case "Bottom":
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(0, 0, 25), Quaternion.identity);
                instGameObject = newMap.transform.Find("Top").gameObject;
                instGameObject.SetActive(false);
              //   collidedObjects.Clear();
                break;
            case "TopRight":
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(-25, 0, -25), Quaternion.identity);
                instGameObject = newMap.transform.Find("BottomLeft").gameObject;
                instGameObject.SetActive(false);
              //   collidedObjects.Clear();
                break;
            case "TopLeft":
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(25, 0, -25), Quaternion.identity);
                instGameObject = newMap.transform.Find("BottomRight").gameObject;
                instGameObject.SetActive(false);
             //    collidedObjects.Clear();
                break;
            case "BottomRight":
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(-25, 0, 25), Quaternion.identity);
                instGameObject = newMap.transform.Find("TopLeft").gameObject;
                instGameObject.SetActive(false);
              //    collidedObjects.Clear();
                break;
            case "BottomLeft":
                collidedObjects.Remove(gameObjectCol);
                gameObjectCol.SetActive(false);
                newMap = Instantiate(MapChunks[rand], mapPointTransform.position + new Vector3(25, 0, 25), Quaternion.identity);
                instGameObject = newMap.transform.Find("TopRight").gameObject;
                instGameObject.SetActive(false);
              //    collidedObjects.Clear();
                break;
            default:
                Debug.Log("nothing to switch in checkandspawn script");
                break;
        }
    }
}

   