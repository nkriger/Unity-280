using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Create a working input system for camera and character movement

    public float speed;
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
    }

    void movement()
    {
        Vector3 moveVec = playerInput.Movement.WASD.ReadValue<Vector3>();
        transform.Translate(moveVec * speed * Time.deltaTime);
    }

    void mouseCheck()
    {

    }

}
