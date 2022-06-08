using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static Dictionary<Int32, LevelInfo> levelInfos = 
    new Dictionary<Int32, LevelInfo>{

    };
    public static Dictionary<String, Int32> sceneBindings = 
    new Dictionary<String, Int32>(){
        {"Blaster Challenge", 3}, 

    };

    public static void SetInfoByID(int id) //note that id means level number, not index
    {
        SetInfo(levelInfos[id]); 
    }

    public static int GetSceneById(int id)
    {
        return sceneBindings[levelInfos[id].GetLevelType()];
    }

    public static void SetInfo(LevelInfo info)
    {
        switch(info.GetLevelType())
        {
            case "Blaster Challenge":
                SetInfoBC((LevelInfoBC)info);
                break;
        }
    }

    public static void SetInfoBC(LevelInfoBC info) //blaster challenge
    {
        mover.availableQuestions = info.availableQuestions;
        mover.speed = info.speed;
    }
}