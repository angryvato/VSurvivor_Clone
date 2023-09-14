using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : MonoBehaviour
{
    public float _speed = 1.0f;
    private Transform _targetTransform;
    public GameObject _targetObject;

    private void Awake()
    {
        _targetObject = GameObject.FindGameObjectWithTag("Player");
        _targetTransform = _targetObject.transform;
    }

    private void Update()
    {
        float _step = _speed * Time.deltaTime;
        transform.LookAt( _targetTransform );
        transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _step);

        if (Vector3.Distance(transform.position, _targetTransform.position) < 0.01f)
        {
            //Debug.Log("I've reached the player");
        }
    }
}
