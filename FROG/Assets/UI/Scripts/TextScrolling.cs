using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScrolling : MonoBehaviour
{
    public RectTransform currentBlock; //block of text*
    private float k = 1f;

    void Start()
    {
        k = Screen.height;
    }

    void Update()
    {
        float moveY = 0.0f;
        if(Input.touchCount > 0)
            moveY = - Input.GetTouch(0).deltaPosition.y / k;
        
        Vector2 p = currentBlock.pivot;
        currentBlock.pivot = new Vector2(p.x, p.y + moveY);


        Debug.Log(p);
    }
}
