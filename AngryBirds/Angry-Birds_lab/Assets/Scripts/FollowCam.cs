using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 1. cam sits at an initial pos. doesnt move during aiming mode
 * 2. one projectile is launched, cam follows tge projectile (but we probably need some easing for a more natural feel
 * 3. as the cam moves up in the air, we need tp zoom out so player can sti;; see the ground
 * 4. when projectil is at rest, stop following that proj abd return to the initial pos
 * 
 * 
 * issues
 * 1. projectile flies off the edge of ground
 * 2. projectile does not stop on the ground
 * 3. when projectile is launched the camera jumps to the position (looks bad)
 * 4. when projectile is at certain height all we see is sky (hard to judge movement)
 */

public class FollowCam : MonoBehaviour
{
    //Point of intrest - what the camerais going to follow
    public GameObject poi;
    //initial z pos of the camera
    public float camZ;

    //variable for easing
    public float easing = 0.05f;


    static public FollowCam Instance;

    public Vector2 minXY;

    private void Awake()
    {
        Instance = this;
        camZ = this.transform.position.z;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraMovement();
    }

    private void cameraMovement()
    {
        //only moves if there is something to follow
        //if (poi == null) return;

        //get position of poi
        //Vector3 destination = poi.transform.position;
        Vector3 destination;

        if(poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = poi.transform.position;

            //if poi is a projectile, check to see if its at rest
            if(poi.tag == "projectile")
            {
                //if poi is not moving
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {
                    poi = null;
                }
                
            }
            //limiting x andy values so the floor isnt shown as much
            destination.x = Mathf.Max(minXY.x, destination.x);
            destination.y = Mathf.Max(minXY.y, destination.y);

            //set orthographic size to keep ground in view
            this.GetComponent<Camera>().orthographicSize = destination.y + 10;

            destination = Vector3.Lerp(transform.position, destination, easing);
        }

        
        //retain the destination.z of camZ
        destination.z = camZ;

        //move the camera to the destination
        transform.position = destination;
    }
}
