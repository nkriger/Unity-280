using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Moveset
{
    //Create a working input system for camera and character movement
    
    private PlayerInput playerInput;
    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerInput.Enable();
    }

    private void Update()
    {
        movement();
        guardCheck();
        stance();
    }

    void movement()
    {
        /*
        Vector3 moveVec = playerInput.Movement.WASD.ReadValue<Vector3>();
        transform.Translate(moveVec * speed * Time.deltaTime);
        */
        //removed to focus on attack freely
    }
    private void guarding()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            guardUp = true;
        }
    }
    
}
