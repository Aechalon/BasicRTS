using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public Vector2 panLimit;
    public float panBorderWidth = 10f;

    public float scrollSpeed = 50f;
    public float minY = 50f;
    public float maxY = 120f;
    private void Update()
    {

        Vector3 pos = transform.position;

        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderWidth)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderWidth)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") ||   Input.mousePosition.y <= panBorderWidth)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderWidth)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        transform.position = pos;
    }
}
