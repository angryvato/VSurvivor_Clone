using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class MapSpawnManager : MonoBehaviour
{
    public List<GameObject> spawnPoints;
    public List<GameObject> mapPrefabs;
    public GameObject groundMap;
    public GameObject mapCenterPoint;
    public GameObject player;
    public Transform mapPointTransform;
    GameObject newMap;
    GameObject instGameObject;
    public bool connected;
    string objectTag;

    public float distance = 25;

    private void Awake()
    {
       // spawnPoints = new List<GameObject>();
       // mapPrefabs = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            if(collision.gameObject.tag == "MapCenter")
            {
                Debug.Log("Found MapCenter by tag");

                mapCenterPoint = collision.gameObject;
                groundMap = mapCenterPoint.transform.Find("GroundMap").gameObject;
                AddToList();
            }
        }
    }

    void AddToList()
    {
        Debug.Log("Currently in AddToList method");

        spawnPoints.Add(groundMap.transform.Find("Left").gameObject);
        spawnPoints.Add(groundMap.transform.Find("Right").gameObject);
        spawnPoints.Add(groundMap.transform.Find("Top").gameObject);
        spawnPoints.Add(groundMap.transform.Find("Bottom").gameObject);
        spawnPoints.Add(groundMap.transform.Find("TopLeft").gameObject);
        spawnPoints.Add(groundMap.transform.Find("TopRight").gameObject);
        spawnPoints.Add(groundMap.transform.Find("BottomLeft").gameObject);
        spawnPoints.Add(groundMap.transform.Find("BottomRight").gameObject);
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, this.mapCenterPoint.transform.position) >= distance)
            this.groundMap.SetActive(false);
        else if (Vector3.Distance(player.transform.position, this.mapCenterPoint.transform.position) < distance)
            this.groundMap.SetActive(true);

        if(Vector3.Distance(player.transform.position, this.mapCenterPoint.transform.position) < distance)
        {  
            if(spawnPoints != null)
            {
                Debug.Log("Spawnpoints is not NULL!");
                CheckToSpawn();
            }
        }
    }

    private void CheckToSpawn()
    {
        foreach (GameObject go in spawnPoints)
        {
            if (go.GetComponent<ConnectCheck>().isConnected == false)
            {
                objectTag = go.tag;
                mapPointTransform = go.transform;
                connected = go.GetComponent<ConnectCheck>().isConnected;
                SpawnSwitch();
            }
        }
    }

    void SpawnSwitch()
    {
        int rand = UnityEngine.Random.Range(0, mapPrefabs.Count);

        switch (objectTag)
        {
            case "Right":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(-25, 0, 0), Quaternion.identity);
                instGameObject = newMap.transform.Find("Left").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("Right").gameObject);
                break;
            case "Left":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(25, 0, 0), Quaternion.identity);
                instGameObject = newMap.transform.Find("Right").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("Left").gameObject);
                break;
            case "Top":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(0, 0, -25), Quaternion.identity);
                instGameObject = newMap.transform.Find("Bottom").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("Top").gameObject);
                break;
            case "Bottom":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(0, 0, 25), Quaternion.identity);
                instGameObject = newMap.transform.Find("Top").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("Bottom").gameObject);
                break;
            case "TopRight":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(-25, 0, -25), Quaternion.identity);
                instGameObject = newMap.transform.Find("BottomLeft").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("TopRight").gameObject);
                break;
            case "TopLeft":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(25, 0, -25), Quaternion.identity);
                instGameObject = newMap.transform.Find("BottomRight").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("TopLeft").gameObject);
                break;
            case "BottomRight":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(-25, 0, 25), Quaternion.identity);
                instGameObject = newMap.transform.Find("TopLeft").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("BottomRight").gameObject);
                break;
            case "BottomLeft":
                connected = true;
                newMap = Instantiate(mapPrefabs[rand], mapPointTransform.position + new Vector3(25, 0, 25), Quaternion.identity);
                instGameObject = newMap.transform.Find("TopRight").gameObject;
                instGameObject.GetComponent<ConnectCheck>().isConnected = true;
                spawnPoints.Remove(groundMap.transform.Find("BottomLeft").gameObject);
                break;
            default:
                Debug.Log("nothing to switch in SpawnSwitch statement");
                break;
        }
    }
}
