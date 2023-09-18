using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapPointCheck : MonoBehaviour
{

    string currentTag = "";
    string colliderTag = "";
    public GameObject collidedObject;
    public List<GameObject> collidedArray;
    

    private void Awake()
    {
        currentTag = transform.tag;   
        collidedArray = new List<GameObject>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            // colliderTag = other.tag;
            //collidedObject = other.gameObject;
            collidedArray.Add(other.gameObject);
            CheckTag();
        }
    }
    

    private void CheckTag()
    {
        switch (currentTag)
        {
            case "Right":
                Debug.Log("CurrentTag is RIGHT, checking for and disabling LEFT tag");
                foreach (GameObject item in collidedArray)
                {
                    if (item.name == "Left")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }
                break;
            case "Left":
                Debug.Log("CurrentTag is LEFT, checking for and disabling RIGHT tag");
                foreach (GameObject item in collidedArray)
                {
                    if (item.name == "Right")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }
                break;
            case "Top":
                Debug.Log("CurrentTag is TOP, checking for and disabling BOTTOM tag");
                foreach (GameObject item in collidedArray)
                {
                    if (item.name == "Bottom")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }
                break;
            case "Bottom":
                Debug.Log("CurrentTag is BOTTOM, checking for and disabling TOP tag");
                foreach (GameObject item in collidedArray)
                {
                    if (item.name == "Top")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }
                break;
            case "TopRight":
                Debug.Log("CurrentTag is TOPRIGHT, checking for and disabling BOTTOMLEFT tag");
                foreach (GameObject item in collidedArray)
                {
                    if (item.name == "BottomLeft")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }
                break;
            case "TopLeft":
                Debug.Log("CurrentTag is TOPLEFT, checking for and disabling BOTTOMRIGHT tag");
                foreach (GameObject item in collidedArray)
                {
                    if (item.name == "BottomRight")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }
                break;
            case "BottomRight":
                Debug.Log("CurrentTag is BOTTOMRIGHT, checking for and disabling TOPLEFT tag");

                foreach (GameObject item in collidedArray)
                {
                    if(item.name == "TopLeft")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }                
                break;
            case "BottomLeft":
                Debug.Log("CurrentTag is BOTTOMLEFT, checking for and disabling TOPRIGHT tag");
                foreach (GameObject item in collidedArray)
                {
                    if (item.name == "TopRight")
                    {
                        collidedObject = item.gameObject;
                        collidedObject.SetActive(false);
                        this.gameObject.SetActive(false);
                    }
                }
                break;
            default:
                break;
        }
    }
}
