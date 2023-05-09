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
                    Debug.Log("top");
                }
                if (collision.gameObject.CompareTag("Right"))
                {
                    Debug.Log("right");
                }
                if (collision.gameObject.CompareTag("Left"))
                {
                    Debug.Log("left");
                }
            }
        }
    
}
