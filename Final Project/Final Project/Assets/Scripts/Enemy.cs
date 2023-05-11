using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Moveset
{
    float randomNumber;
    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        //float randomNumber = Random.Range(0f, 100f);
        
        guardUp = true;
        stanceSwitch();
    }

    // Update is called once per frame
    
    private void stanceSwitch()
    {
        StartCoroutine(StanceSwitchTimer());
    }
    private void randomStance()
    {
        randomNumber = Random.Range(0f, 100f);
        if (randomNumber <= 33f)
        {
            Up = true;
            
        }
        else if (randomNumber >= 66f)
        {
            Left = true;
           
        }
        else
        {
            Right = true;
            
        }
    }
    IEnumerator StanceSwitchTimer()
    {
        Up = false;
        Left = false;
        Right = false;
        
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);
        randomStance();
        StartCoroutine(AttackRand());
       
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        //Up = false;
        //Left = false;
        //Right = false;
        //randomStance();
        //StartCoroutine(AttackRand());
        StartCoroutine(StanceSwitchTimer());
    }
    IEnumerator AttackRand()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(onHit());
        attack();
    }
    IEnumerator onHit()
    {
        yield return new WaitForSeconds(.6f);
        Debug.Log("enemy started attack");
        //Debug.Log("Up: " + Up);
       // Debug.Log("Right: " + Right);
        //Debug.Log("Left: " + Left);
        if (Up == true)
        {
            Debug.Log("attacking up");
            if (player.GetComponent<PlayerController>().Up == true)
            {
                Debug.Log("Blocked Up");
                //Up = true;
            }
            else
            {
                Debug.Log("Hit top");
                player.GetComponent<PlayerController>().Health -= 1;
                //Up = true;
            }

        }
        if (Right == true)
        {
            Debug.Log("attacking right");
            if (player.GetComponent<PlayerController>().Right == true)
            {
                Debug.Log("Blocked Right");
                //Right = true;
            }
            else
            {
                Debug.Log("Hit Right");
                player.GetComponent<PlayerController>().Health -= 1;
                //Right = true;
            }

        }
        if (Left == true)
        {
            Debug.Log("attacking left");
            if (player.GetComponent<PlayerController>().Left == true)
            {
                Debug.Log("Blocked Left");
                //Left = true;
            }
            else
            {
                Debug.Log("Hit Left");
                player.GetComponent<PlayerController>().Health -= 1;
                //Left = true;
            }
        }
    }
}
