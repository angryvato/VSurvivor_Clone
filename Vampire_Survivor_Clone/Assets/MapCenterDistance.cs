using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCenterDistance : MonoBehaviour
{
    public GameObject mapCenterPoint;
    public GameObject player;
    public GameObject groundMap;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.mapCenterPoint.transform.position) >= 75)
            this.groundMap.SetActive(false);
        else if (Vector3.Distance(player.transform.position, this.mapCenterPoint.transform.position) < 75)
            this.groundMap.SetActive(true);
    }
}
