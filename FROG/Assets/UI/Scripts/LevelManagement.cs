﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    public static int maxLevel = 5;
    public GameObject levelButtonPrefab;
    private float biasX = 1.2f, biasY = 1.25f;
    private float borderTop = 6.0f, borderBottom = 4.5f;

    private float k;
    private GameObject mainCam;

    void Start()
    {
        for(int i = 1; i <= maxLevel; i++)
        {
            GameObject obj = Instantiate(levelButtonPrefab, new Vector3((1 - i % 3) * biasX, i * biasY, 0.0f), Quaternion.identity);
            obj.name = "lvl" + i.ToString();
            obj.GetComponentInChildren<Text>().text = i.ToString();
        }

        mainCam = GameObject.FindWithTag("MainCamera");

        k = Screen.height / 10.0f;
    }

    void Update()
    {
        float moveCamY = 0.0f;
        if(Input.touchCount > 0)
            moveCamY = - Input.GetTouch(0).deltaPosition.y / k;
        mainCam.transform.Translate(0.0f, moveCamY, 0.0f);
        if(mainCam.transform.position.y > borderTop)
            mainCam.transform.Translate(0.0f, - mainCam.transform.position.y + borderTop, 0.0f);
        if(mainCam.transform.position.y < borderBottom)
            mainCam.transform.Translate(0.0f, - mainCam.transform.position.y + borderBottom, 0.0f);
    }
}
