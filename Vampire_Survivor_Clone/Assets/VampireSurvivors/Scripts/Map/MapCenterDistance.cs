using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCenterDistance : MonoBehaviour
{
    public GameObject mapCenterPoint;
    public GameObject player;
    public GameObject groundMap;
    public Renderer groundRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mapCenterPoint = this.gameObject;
        groundMap = this.transform.Find("GroundMap").gameObject;
        groundRenderer = groundMap.transform.Find("GroundTile").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, mapCenterPoint.transform.position) >= 60)
            groundRenderer.enabled = false;
        else if (Vector3.Distance(player.transform.position, mapCenterPoint.transform.position) < 60)
            groundRenderer.enabled = true;
    }
}
