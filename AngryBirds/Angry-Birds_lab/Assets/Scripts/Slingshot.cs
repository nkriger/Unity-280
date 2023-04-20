using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField]
    public GameObject launchPoint;

    public GameObject prefabProjectile;

    [SerializeField]
    private Vector3 launchPos;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private bool aimingMode;


    //when game starts make sure we have access to the launchPoint
    private void Awake()
    {
        Transform launchPointTransform = transform.Find("launchPoint");
        launchPoint = launchPointTransform.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTransform.position;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered");
        launchPoint.SetActive(true);
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        launchPoint.SetActive(false);
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
}
