using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudCrafter : MonoBehaviour
{
    //variable game objects to hold prefabs
    public int numClouds = 40;

    //# of clouds to make

    //array to hold prefabs
    public GameObject[] cloudPrefabs;

    //min and max pos
    public Vector3 cloudPosMin;

    public Vector3 cloudPosMax;

    //min scale and max scale

    public float cloudScaleMin;

    public float cloudScaleMax;

    //speed for each cloud

    public float cloudSpeedMult = 0.5f;

    // hold referance for each cloud so we can track them

    public GameObject[] cloudInstances;

    public void Awake()
    {
        //make array large enough to hold all instances
        cloudInstances = new GameObject[numClouds];

        //find cloudAnchor parent object GameObject.Find looks through susyem top to bottom for gameobjects
        GameObject anchor = GameObject.Find("Cloud Anchor");

        //make all the clouds
        GameObject cloud;
        for (int index = 0; index < numClouds; index++)
        {
            //pick an int between 0 and numClouds
            //note Random.range will never return the max number FOR INTS
            int prefabNum = Random.Range(0, cloudPrefabs.Length);

            cloud = Instantiate(cloudPrefabs[prefabNum]) as GameObject;
            //posiiton the cloud
            Vector3 cPos = Vector3.zero;
            cPos.x = Random.Range(cloudPosMin.x, cloudPosMax.x);
            cPos.y = Random.Range(cloudPosMin.y, cloudPosMax.y);

            //scale the cloud Random.value= random float between 0 and 1
            float scaleU = Random.value;
            float scaleValue = Mathf.Lerp(cloudScaleMin, cloudScaleMax, scaleU);

            //smaller clouds (wiht smaller scaleU) should be near the ground (simultating depth)
            cPos.y = Mathf.Lerp(cloudPosMin.y, cPos.y, scaleU);

            //smallest clouds closer to the ground
            cPos.z = 100 - 90 * scaleU;

            //aply the new values to the clouds
            cloud.transform.position = cPos;
            cloud.transform.localScale = scaleValue * Vector3.one;

            cloudInstances[index] = cloud;
            cloud.transform.SetParent(anchor.transform);
        }
    }

    private void Update()
    {
        //iterate over each cloud that was created
        foreach (GameObject cloud in cloudInstances)
        {
            //get the cloud scale and position
            float scaleVal = cloud.transform.localScale.x;
            Vector3 cPos = cloud.transform.position;

            //move the cloud (left)
            cPos.x -= scaleVal * Time.deltaTime * cloudSpeedMult;

            //if cloud moves to far to the left reset it to the far right
            if (cPos.x <= cloudPosMin.x)
            {
                cPos.x = cloudPosMax.x;
            }

            cloud.transform.position = cPos;
        }
    }

}
