using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Moveset
{
    float randomNumber;
   
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
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        randomStance();
       
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);


        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Up = false;
        Left = false;
        Right = false;
        randomStance();
    }
}
