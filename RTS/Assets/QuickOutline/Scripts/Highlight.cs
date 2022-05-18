using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public Outline outline;
    [SerializeField] private bool ally;
    public void Start()
    {
        outline = GetComponent<Outline>();

    }
    public void Update()
    {
        if(ally)
        {
            outline.OutlineColor = Color.green;
        }
        else
        {
            outline.OutlineColor = Color.red;
        }
    }
    private void OnMouseOver()
    {
      
        outline.OutlineWidth = 6;
    }
    private void OnMouseExit()
    {
        outline.OutlineWidth = 2;
    }
}
