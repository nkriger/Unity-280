using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public static Slingshot Instance;

    [SerializeField]
    public GameObject stanceIcon;

    public GameObject prefabProjectile;

    [SerializeField]
    public Vector3 launchPos;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private bool aimingMode;
    public float velocityMult;


    //when game starts make sure we have access to the launchPoint
    private void Awake()
    {
        Transform stanceIconTransform = transform.Find("stanceIcon");
        stanceIcon = stanceIconTransform.gameObject;
        stanceIcon.SetActive(false);
        launchPos = stanceIconTransform.position;
        Instance = this;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered");
        stanceIcon.SetActive(true);
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        stanceIcon.SetActive(false);
    }
    private void OnMouseDown()
    {
        //player has pressed mouse button for slingshot

        //set aiming mode to true
        aimingMode = true;

        //instantiate a projectile
        projectile = Instantiate(prefabProjectile);

        //move it to the launch point
        projectile.transform.position = launchPos;

        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Update()
    {
        mousePosTracker();
        guardUp();
    }

    private void mousePosTracker()
    {
        //if slingshot is not in aiminmode dont run this code
        if (!aimingMode) return;

        //get the current mouse position in 2D screen space
        Vector3 mousePos2D = Input.mousePosition;
        //this mouse locator is on the old input system if u want to run it with the new system by activated Both input systems in Project settings/player

        //convert mouse Pos into 3d world space
        //use the camera to get from 3d into 2d space
        mousePos2D.z = Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //find the delta (change in) from launch position to the new mousePos3D
        //delta of 32 and 27 is 5

        Vector3 mouseDelta = mousePos3D - launchPos;

        //limit mouseDelta to radius of sphere collider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //move the projectile to this new pos
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;

        //check if mouse is released
        if (Input.GetMouseButtonUp(0))
        {
            //left mouse released
            aimingMode = false;
            projectile.GetComponent<Rigidbody>().isKinematic = false;
            projectile.GetComponent<Rigidbody>().velocity = -mouseDelta * velocityMult;

            //FollowCam.Instance.poi = projectile;
            projectile = null;

        }
    }
    void guardUp()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            aimingMode = true;
        }
    }
}
