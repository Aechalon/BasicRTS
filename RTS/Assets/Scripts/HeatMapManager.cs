using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatMapManager : MonoBehaviour
{
    public int box1;
    public int box2;
    public int box3;

    private void Update()
    {
        box1 = PlayerPrefs.GetInt("p_box1");
        box2 = PlayerPrefs.GetInt("p_box2");
        box3 = PlayerPrefs.GetInt("p_box3");
    }
    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();    
    }
}
