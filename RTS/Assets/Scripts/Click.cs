using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour

{

    private Vector3 mOffset;
    public Camera cam;
    public bool selected;

    private float mZCoord;

   
    void OnMouseDown()

    {

        mZCoord = cam.WorldToScreenPoint(gameObject.transform.position).z;
  


        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        selected = true;

    }



    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points
        

        return cam.ScreenToWorldPoint(mousePoint);

       

    }
 



    // selected = true;
    //transform.position = GetMouseAsWorldPoint() + mOffset;




}

