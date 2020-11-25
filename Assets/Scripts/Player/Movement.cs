using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float _speed = 20f;
    private CharacterController _characterController;
    private float _moveX;
    private float _moveY;
    private Vector3 _velocity;
    private float _gravity = -9f;
    private Vector3 _gravityVector;

    private bool _isAiming;
    public bool isTrapped = false;
   
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _gravityVector = new Vector3(0, _gravity, 0);
        _isAiming = false;
    }

    
    void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveY = Input.GetAxis("Vertical");
        _velocity = new Vector3(_moveX, 0f, _moveY).normalized * _speed;

        if (!isTrapped)
        {
            _characterController.Move(_velocity * Time.deltaTime + _gravityVector);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            _isAiming = true;
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            _isAiming = false;
        }
            
        if (_velocity.magnitude > 0.1f && !_isAiming)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_velocity), Time.deltaTime * 700);
        }
    }
}
