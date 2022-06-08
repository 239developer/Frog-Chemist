using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectConnector : MonoBehaviour
{
    //make sure that you input global positions
    public static void ConnectTwo(GameObject line, Vector3 pos0, Vector3 pos1)
    {
        GameObject canvas = GameObject.FindWithTag("Main Canvas");
        float canvasScale = canvas.transform.localScale.y;

        line.transform.position = 0.5f * (pos0 + pos1);
        line.transform.rotation = Quaternion.identity;
        float dx = pos1.x - pos0.x;
        float dy = pos1.y - pos0.y;
        float delta = -(float)Math.Atan(dx / dy) * 180f / (float)Math.PI;
        line.transform.Rotate(0f, 0f, delta);
        float h = line.GetComponent<RectTransform>().rect.height;
        Vector3 s = line.transform.localScale;
        line.transform.localScale = new Vector3(s.x, (pos1 - pos0).magnitude / h / canvasScale, s.z);
    }
}
