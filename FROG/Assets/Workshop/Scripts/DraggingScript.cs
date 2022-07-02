using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingScript : MonoBehaviour
{
    private GameObject heldItem = null;
    private Vector3 lastPos = Vector3.zero;

    void TryToPick(Vector2 point)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(point);
        RaycastHit hit;

        if (Physics.Raycast(worldPoint, Vector3.forward, out hit))
        {
            heldItem = hit.collider.gameObject;
            lastPos = heldItem.transform.position;
        }
    }

    void DragObject(Vector2 point)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(point);
        pos.z = lastPos.z;
        pos = (pos + lastPos) * 0.5f;
        lastPos = pos;
        heldItem.transform.position = pos;
    }

    void DropObject(Vector2 point)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(point);
        pos.z = 0f;
        heldItem = null;
    }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    TryToPick(touch.position);
                    break;
                case TouchPhase.Moved:
                    if(heldItem != null) DragObject(touch.position);
                    break;
                case TouchPhase.Ended:
                    if(heldItem != null) DropObject(touch.position);
                    break;  
            }
        }

        // var x = Input.mousePosition;
        // Vector2 pos = new Vector2(x.x, x.y);
        // if(Input.GetMouseButtonDown(0))
        //     TryToPick(pos);
        // else if(Input.GetMouseButtonUp(0)){
        //     if(heldItem != null) DropObject(pos);}
        // else if(Input.GetMouseButton(0))
        //     if(heldItem != null) DragObject(pos);
    }
}
