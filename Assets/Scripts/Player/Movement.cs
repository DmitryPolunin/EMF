using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 20f;
    private CharacterController _characterController;
    private float moveX;
    private float moveY;
    private Vector3 velocity;
    private float gravity = -9f;
    private Vector3 gravityVector;

    private bool isAiming;
    public bool isTrapped = false;
   
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        gravityVector = new Vector3(0, gravity, 0);
        isAiming = false;
    }

    
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        velocity = new Vector3(moveX, 0f, moveY).normalized * speed;

        if (!isTrapped)
        {
            _characterController.Move(velocity * Time.deltaTime + gravityVector);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            isAiming = true;
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            isAiming = false;
        }
            
        if (velocity.magnitude > 0.1f && !isAiming)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * 700);
        }
    }
}
