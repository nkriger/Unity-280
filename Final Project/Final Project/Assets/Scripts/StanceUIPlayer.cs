using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceUIPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject top;
    public GameObject right;
    public GameObject left;
    //public ScriptableObject Stance;

    // Update is called once per frame
    void Update()
    {
        UICheck();
    }
    private void UICheck()
    {
        if (player.GetComponent<PlayerController>().Up == true)
        {
            top.SetActive(true);
        }
        else
        {
            top.SetActive(false);
        }
        if (player.GetComponent<PlayerController>().Right == true)
        {
            right.SetActive(true);
        }
        else
        {
            right.SetActive(false);
        }
        if (player.GetComponent<PlayerController>().Left == true)
        {
            left.SetActive(true);
        }
        else
        {
            left.SetActive(false);
        }
    }
}
