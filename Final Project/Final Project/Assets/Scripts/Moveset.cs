using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveset : MonoBehaviour
{
    //speed of charaters
    public float speed;

    //Health
    public int Health;

    //2 different bool states for normal movement and stanced
    public bool guardUp;
    public bool guardDown;

    //3 substances when guard is up
    public bool neutral;
    public bool Up;
    public bool Left;
    public bool Right;
    public bool Attacking;
    public bool Hit;

    
    public GameObject topAttack;
    public GameObject rightAttack;
    public GameObject leftAttack;


    public void Update()
    {
        guardCheck();
        stance();
    }

    public void guardCheck()
    {
        if (!guardUp)
        {
            guardDown = true;
        }
        else
        {
            guardDown = false;
        }
        if (guardDown)
        {           
            Up = false;
            Left = false;
            Right = false;
            neutral = false;           
        }
    }

    public void stance()
    {
        /*
        if (guardUp && !Up && !Left && !Right)
        {
            neutral = true;
            Up = false;
            Left = false;
            Right = false;
        }
        */
        if (neutral)
        {
            //Left = false;
            //Right = false;
            //Up = false;
        }
        if (Up)
        {                  
            Left = false;
            Right = false;
            //neutral = false;
        }
        else if (Left)
        {           
            Up = false;
            Right = false;
            //neutral = false;
            //Debug.Log("Left");
        }
        else if (Right)
        {          
            Up = false;
            Left = false;
            //neutral = false;
        }
    }
    public void attack()
    {
        StartCoroutine(Swing());
        StartCoroutine(SwingUI());
    }
    public IEnumerator Swing()
    {
        neutral = true;
        //Print the time of when the function is first called.
        //Debug.Log("Started Attack : " + Time.time);
        Attacking = true;

        //yield on a new YieldInstruction that waits for .7 seconds.
        yield return new WaitForSeconds(.7f);
        Hit = true;

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Hit = false;
        Attacking = false;
        neutral = false;
    }
    public IEnumerator SwingUI()
    {
        if (Up == true)
        {
            topAttack.SetActive(true);
        }
        if (Right == true)
        {
            rightAttack.SetActive(true);
        }
        if (Left == true)
        {
            leftAttack.SetActive(true);
        }
        //Print the time of when the function is first called.
        //Debug.Log("Started Attack : " + Time.time);


        //yield on a new YieldInstruction that waits for .7 seconds.
        yield return new WaitForSeconds(.7f);

        topAttack.SetActive(false);
        rightAttack.SetActive(false);
        leftAttack.SetActive(false);
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
