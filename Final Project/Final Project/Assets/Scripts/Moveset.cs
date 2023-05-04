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
       
        if (Up)
        {                  
            Left = false;
            Right = false;
            neutral = false;
        }
        if (Left)
        {           
            Up = false;
            Right = false;
            neutral = false;
            Debug.Log("Left");
        }
        if (Right)
        {          
            Up = false;
            Left = false;
            neutral = false;
        }
    }
}
