using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MapController : MonoBehaviour
{
    public List<GameObject> mapChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noMapPosition;
    public LayerMask mapMask;
    Movement playerMovement;
    public GameObject currentMap;
    public GameObject checkSphere;
    Collider[] hitColliders;

    void Start()
    {
        playerMovement = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        NewMapChecker();
    }

 //   void MapChecker()
 //   {
 //       if(!currentMap)
 //       {
 //           return;
 //       }
 //
 //       //Left
 //       if(playerMovement.movement.x > 0 && playerMovement.movement.y == 0)
 //       {          
 //           Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Left").position + new Vector3(25, 0, 0), checkerRadius, mapMask);
 //           if(hitColliders.Length <= 0)
 //           {
 //               noMapPosition = currentMap.transform.Find("Left").position + new Vector3(25, 0, 0);
 //               SpawnMap();
 //           }
 //       }
 //       //Right
 //       if (playerMovement.movement.x < 0 && playerMovement.movement.y == 0)
 //       {        
 //           Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Right").position + new Vector3(-25, 0, 0), checkerRadius, mapMask);
 //           if (hitColliders.Length <= 0)
 //           {
 //               noMapPosition = currentMap.transform.Find("Right").position + new Vector3(-25, 0, 0);
 //               SpawnMap();
 //           }
 //       }
        //Up
 //       if (playerMovement.movement.x == 0 && playerMovement.movement.y < 0)
 //       {        
//            Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Top").position + new Vector3(0, 0, -25), checkerRadius, mapMask);
 //           if (hitColliders.Length <= 0)
 //           {
//                noMapPosition = currentMap.transform.Find("Top").position + new Vector3(0, 0, -25);
 //               SpawnMap();
//            }
//        }
        //Down
 //       if (playerMovement.movement.x == 0 && playerMovement.movement.y > 0)
 //       {        
 //           Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Bottom").position + new Vector3(0, 0, 25), checkerRadius, mapMask);
 //           if (hitColliders.Length <= 0)
 //           {
 //               noMapPosition = currentMap.transform.Find("Bottom").position + new Vector3(0, 0, 25);
 //               SpawnMap();
 //           }
 //       }
        //TopRight
//        if (playerMovement.movement.x < 0 && playerMovement.movement.y < 0)
 //       {        
 //           Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("TopRight").position + new Vector3(-25, 0, -25), checkerRadius, mapMask);
 //           if (hitColliders.Length <= 0)
 //           {
 //               noMapPosition = currentMap.transform.Find("TopRight").position + new Vector3(-25, 0, -25);
 //               SpawnMap();
 //           }
 //       }
        //TopLeft
 //       if (playerMovement.movement.x > 0 && playerMovement.movement.y < 0)
//        {         
 //           Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("TopLeft").position + new Vector3(25, 0, -25), checkerRadius, mapMask);
 //           if (hitColliders.Length <= 0)
 //           {
 //               noMapPosition = currentMap.transform.Find("TopLeft").position + new Vector3(25, 0, -25);
 //               SpawnMap();
 //           }
 //       }
        //BottomRight
 //       if (playerMovement.movement.x < 0 && playerMovement.movement.y > 0)
 //       {         
 //           Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("BottomRight").position + new Vector3(-25, 0, 25), checkerRadius, mapMask);
 //           if (hitColliders.Length <= 0)
 //           {
  //              noMapPosition = currentMap.transform.Find("BottomRight").position + new Vector3(-25, 0, 25);
 //               SpawnMap();
 //           }
 //       }
        //BottomLeft
 //       if (playerMovement.movement.x > 0 && playerMovement.movement.y > 0)
 //       {         
 //           Collider[] hitColliders = Physics.OverlapSphere(currentMap.transform.Find("BottomLeft").position + new Vector3(25, 0, 25), checkerRadius, mapMask);
 //           if (hitColliders.Length <= 0)
 //           {
 //               noMapPosition = currentMap.transform.Find("BottomLeft").position + new Vector3(25, 0, 25);
 //               SpawnMap();
 //           }
 //       }
 //   }

    void SpawnMap()
    {
        int Rand = Random.Range(0, mapChunks.Count);
        Instantiate(mapChunks[Rand], noMapPosition, Quaternion.identity);
    }

    void NewMapChecker()
    {
        if (!currentMap)
        {
            return;
        }

        //Left        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Left").position + new Vector3(25, 0, 0), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("Left").position + new Vector3(25, 0, 0);
                SpawnMap();
            }        
        //Right        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Right").position + new Vector3(-25, 0, 0), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("Right").position + new Vector3(-25, 0, 0);
                SpawnMap();
            }        
        //Up        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Top").position + new Vector3(0, 0, -25), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("Top").position + new Vector3(0, 0, -25);
                SpawnMap();
            }        
        //Down        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("Bottom").position + new Vector3(0, 0, 25), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("Bottom").position + new Vector3(0, 0, 25);
                SpawnMap();
            }        
        //TopRight        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("TopRight").position + new Vector3(-25, 0, -25), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("TopRight").position + new Vector3(-25, 0, -25);
                SpawnMap();
            }        
        //TopLeft        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("TopLeft").position + new Vector3(25, 0, -25), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("TopLeft").position + new Vector3(25, 0, -25);
                SpawnMap();
            }        
        //BottomRight        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("BottomRight").position + new Vector3(-25, 0, 25), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("BottomRight").position + new Vector3(-25, 0, 25);
                SpawnMap();
            }        
        //BottomLeft        
            hitColliders = Physics.OverlapSphere(currentMap.transform.Find("BottomLeft").position + new Vector3(25, 0, 25), checkerRadius, mapMask);
            if (hitColliders.Length <= 0)
            {
                noMapPosition = currentMap.transform.Find("BottomLeft").position + new Vector3(25, 0, 25);
                SpawnMap();
            }        
    }
}
