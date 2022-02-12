using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScrolling : MonoBehaviour
{
    public RectTransform currentBlock; //block of text*
    public float drag = 0.8f;
    private float maxY = -10000.0f, minY = 10000.0f, height;
    private float k = 1f;
    private float velY = 0f; //Y velocity of text

    void Start()
    {
        currentBlock.pivot = new Vector2(currentBlock.pivot.x, 1f);
        float h = 2160f;
        foreach(RectTransform rt in currentBlock.GetComponentsInChildren<RectTransform>())
        {
            if(rt.pivot.y > maxY)
                maxY = rt.pivot.y;
            if(rt.pivot.y * h - rt.rect.height < minY * h)
                minY = (rt.pivot.y * h - rt.rect.height) / h;
        }
        height = maxY - minY;
        maxY = height;
        minY = 1 - height;

        k = Screen.height;
    }

    void Update()
    {
        if(Input.touchCount > 0)
            velY = - Input.GetTouch(0).deltaPosition.y / k;
        else
            velY -= velY * drag * Time.deltaTime;
        
        Vector2 p = currentBlock.pivot;
        if(p.y + velY > maxY || p.y + velY < minY)
            velY = 0.0f;
        if(p.y > maxY)
            velY = maxY - p.y;
        if(p.y < minY)
            velY = minY - p.y;
        currentBlock.pivot = new Vector2(p.x, p.y + velY);

        Debug.Log(p.y + " " + maxY + " " + minY);
    }
}
