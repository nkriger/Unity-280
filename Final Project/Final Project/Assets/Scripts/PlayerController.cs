using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Moveset
{
    //Create a working input system for camera and character movement
    
    private PlayerInput playerInput;
    private Rigidbody rigidBody;
    public GameObject enemy;
    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerInput.Enable();
    }

    private void Update()
    {
        movement();
        //guardCheck();
        //stance();
        guarding();
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
        if (Input.GetMouseButtonDown(0))
        {
            attack();
            StartCoroutine(onHit());
            //attackSwing();
        }
    }
    
    private void attackSwing()
    {
        //StartCoroutine(SwingUI());
        //enemyStance = enemy.GetComponent<Enemy>();
        StartCoroutine(onHit());
    }
    IEnumerator onHit()
    {
        yield return new WaitForSeconds(.6f);
        if (Up == true)
        {

            if (enemy.GetComponent<Enemy>().Up == true)
            {
                Debug.Log("Blocked Up");
                Up = true;
            }
            else
            {
                Debug.Log("Hit top");
                enemy.GetComponent<Enemy>().Health -= 1;
                Up = true;
            }

        }
        if (Right == true)
        {

            if (enemy.GetComponent<Enemy>().Right == true)
            {
                Debug.Log("Blocked Right");
                Right = true;
            }
            else
            {
                Debug.Log("Hit Right");
                enemy.GetComponent<Enemy>().Health -= 1;
                Right = true;
            }

        }
        if (Left == true)
        {

            if (enemy.GetComponent<Enemy>().Left == true)
            {
                Debug.Log("Blocked Left");
                Left = true;
            }
            else
            {
                Debug.Log("Hit Left");
                enemy.GetComponent<Enemy>().Health -= 1;
                Left = true;
            }

        }
    }
}
