using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle, 
    playing,
    levelEnd
    //no comma on last one... comma tells there is another
}
//tjos os our state manager
public class MissionDemolition : MonoBehaviour
{
    public static MissionDemolition Instance;

    public GameObject[] castles;
    public Text textLevel, textScore;
    public Vector3 castlePos;

    public int level, levelMax, shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Slingshot";

    private void Start()
    {
        Instance = this;
        level = 0;
        levelMax = castles.Length; //sets the max number to = the total amount in the castle Array[]
        StartLevel();
    }

    private void StartLevel()
    {
        //get rid of any castles that exist in scene
        if(castle != null)
        {
            Destroy(castle);
        }
        //instantiate a new castle
        castle = Instantiate(castles[level]);//instantiate calls from castles array and generates level
        castle.transform.position = castlePos;

        //init the shot tracker
        shotsTaken = 0;

        //reset camera
        SwitchView("Both");
        projectileLine.Instance.Clear();//resets the tracking line

        //resets the goal
        Goal.goalMet = false;

        mode = GameMode.playing;

    }

    private void ShowText()
    {
        textLevel.text = "Level: " + (level + 1)+ " of " + levelMax;
        textScore.text = "Shots Taken" + shotsTaken;
    }

    private void Update()
    {
        //this is ok for protoyping but not for production
        ShowText();//do not use show text in update it makes lag instead call it when the nyumber changes
        if(mode == GameMode.playing && Goal.goalMet)
        {
            //change the mode to stop checking for level
            mode = GameMode.levelEnd;

            //zoom out
            SwitchView("Both");

            Invoke("NextLevel", 2f);
        }
    }

    private void NextLevel()
    {
        level++;
        if(level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }
    static public void SwitchView(string eView)
    {
        Instance.showing = eView;
        switch (Instance.showing)
        {
            case "Slingshot":
                FollowCam.Instance.poi = null;
                break;
            case "Castle":
                FollowCam.Instance.poi = Instance.castle;
                break;
            case "Both":
                FollowCam.Instance.poi = GameObject.Find("ViewBoth");
                break;
            default:
                break;
        }
    }
}

