using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceCheck : MonoBehaviour
{
    public GameObject parentGameObject;

    public GameObject player;
        private void OnCollisionEnter(Collision collision)
        {
           
            if (collision.transform.parent == parentGameObject.transform)
            {
                if (collision.gameObject.CompareTag("Top"))
                {
                    player.GetComponent<PlayerController>().Up = true;
                    //Debug.Log("top enter");
                }
                if (collision.gameObject.CompareTag("Right"))
                {
                    player.GetComponent<PlayerController>().Right = true;
                    //Debug.Log("right enter");
                }
                if (collision.gameObject.CompareTag("Left"))
                {
                    player.GetComponent<PlayerController>().Left = true;
                    //Debug.Log("left enter");
                }
            }
        }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.parent == parentGameObject.transform)
        {
            if (collision.gameObject.CompareTag("Top"))
            {
                player.GetComponent<PlayerController>().Up = false;
                //Debug.Log("top exit");
            }
            if (collision.gameObject.CompareTag("Right"))
            {
                player.GetComponent<PlayerController>().Right = false;
                //Debug.Log("right exit");
            }
            if (collision.gameObject.CompareTag("Left"))
            {
                player.GetComponent<PlayerController>().Left = false;
                //Debug.Log("left exit");
            }
        }
    }
}
