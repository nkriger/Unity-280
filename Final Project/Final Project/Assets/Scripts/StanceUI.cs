using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StanceUI : MonoBehaviour
{
    public GameObject enemy;
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
        if (enemy.GetComponent<Enemy>().Up == true)
        {
            top.SetActive(true);
        }
        else
        {
            top.SetActive(false);
        }
        if (enemy.GetComponent<Enemy>().Right == true)
        {
            right.SetActive(true);
        }
        else
        {
            right.SetActive(false);
        }
        if (enemy.GetComponent<Enemy>().Left == true)
        {
            left.SetActive(true);
        }
        else
        {
            left.SetActive(false);
        }
    }
}
