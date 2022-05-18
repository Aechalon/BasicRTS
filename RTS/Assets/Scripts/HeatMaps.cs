using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatMaps : MonoBehaviour
{
    public HeatMapManager hmManager;

    public bool hm1;
    public bool hm2;
    public bool hm3;

    public void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            if (hm1)
            {
                PlayerPrefs.SetInt("p_box1", hmManager.box1 +=1);
            }
            if (hm2)
            {
                PlayerPrefs.SetInt("p_box2", hmManager.box2 += 1);
            }
            if (hm3)
            {
                PlayerPrefs.SetInt("p_box3", hmManager.box3 += 1);
            }
            PlayerPrefs.Save();
        }
    }

}
