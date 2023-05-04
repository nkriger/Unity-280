using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "projectile")
        {
            //it is a projectile, so set goal met to true
            Goal.goalMet = true;

            //lets add some feedback
            Color c = GetComponent<MeshRenderer>().material.color;
            c.a = 1.0f; //sets the color.alpha to 100%
            GetComponent<MeshRenderer>().material.color = c;
        }
    }
}
