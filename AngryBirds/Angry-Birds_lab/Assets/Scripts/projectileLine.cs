using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileLine : MonoBehaviour
{

    [SerializeField]
    

    
    static public projectileLine Instance;
    public float minDist = 0.1f;
    public LineRenderer line;
    private GameObject _poi;
    public List<Vector3> points;


    private void Awake()
    {
        //instantiate the singleton
        Instance = this;

        line = GetComponent<LineRenderer>();

        line.enabled = false;

        //initiate the points list
        points = new List<Vector3>();

    }

    public GameObject poi
    {
        get { return _poi; }
        set { 
            _poi = value;
             if(_poi != null)
             {
                //when _poi is set to some new value
                //it resets everything
                line.enabled = false;
                points = new List<Vector3>();
                AddPoint();
             }                    
        }
    }

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();
    }

    public void AddPoint()
    {
        Vector3 pt = _poi.transform.position;
        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            return;
        }

        if (points.Count == 0)
        {
            Vector3 launchPos = Slingshot.Instance.launchPoint.transform.position;
            Vector3 launchPosDiff = pt - launchPos;

            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.SetVertexCount(2);
            //line.positionCount=2

            //set the first 2 points we want to draw
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);

            line.enabled = true;
        }
        else
        {
            points.Add(pt);
            line.SetVertexCount(points.Count);
            line.SetPosition(points.Count - 1, lastPoint);
            line.enabled = true;

        }
    }

    //return location of recently added point
    public Vector3 lastPoint
    {
        get
        {
           if (points == null)
           {
               return Vector3.zero;
           }

           return points[points.Count - 1];
        }
       
    }

    private void FixedUpdate()
    {
        if(poi == null)
        {
            if (FollowCam.Instance.poi != null)
            {
                if (FollowCam.Instance.poi.tag == "projectile")
                {
                    poi = FollowCam.Instance.poi;
                }
                else
                {
                    //didnt find
                    return;
                }
            }
            else
            {
                //didnt find
                return;
            }
        }
        

        AddPoint();

        //once poi is sleeping clear it out
        if (poi.GetComponent<Rigidbody>().IsSleeping())
        {
            poi = null;
        }

    }


}
