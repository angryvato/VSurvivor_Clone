using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float _speed = 1.0f;
    public Vector2 movement;
    public bool _isMoving = false;
    public Vector2 _mousePosition;    
    public Transform _lookTarget;
    public Animator _animator;
    public Camera _camera;    

    PlayerInputShit _input;

    private void Awake()
    {
        _input = new PlayerInputShit();
       // _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Gameplay.Movement.performed += OnMovement;
        _input.Gameplay.Movement.canceled += OnMovement;       
    }
    private void OnDisable()
    {
        _input.Disable();
    }
      

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        //Debug.Log("Movement x is: " + movement.x + "Movement z is: " + movement.y);
      
        transform.LookAt(_lookTarget);

        MovePlayer();
    }

    

    public void MovePlayer()
    {
        
        Vector3 move = new Vector3(movement.x, 0f, movement.y);        

        transform.Translate(move * _speed * Time.deltaTime, Space.World);
        _camera.transform.Translate(move * _speed * Time.deltaTime, Space.World);

        if (movement != Vector2.zero)
        {
            _isMoving = true;
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _isMoving = false;
            _animator.SetBool("isWalking", false);
        }

    }
}
