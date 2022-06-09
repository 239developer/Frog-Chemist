using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static int currentPage = 1;
    public static int currentLevel = 7;
    public static Dictionary<String, Int32> sceneBindings = 
    new Dictionary<String, Int32>(){
        {"Blaster Challenge", 3}, 
        {"Message", 4},
    };

    public static void SetInfoByID(int id) //note that id means level number, not index
    {
        SetInfo(levelInfos[id]); 
    }

    public static int GetSceneById(int id)
    {
        currentLevel = id;
        return sceneBindings[levelInfos[id].GetLevelType()];
    }

    public static void SetInfo(LevelInfo info)
    {
        switch(info.GetLevelType())
        {
            case "Blaster Challenge":
                SetInfoBC((LevelInfoBC)info);
                break;
            case "Message":
                SetInfoMsg((LevelInfoMsg)info);
                break;
        }
    }

    public static void SetInfoBC(LevelInfoBC info) //blaster challenge
    {
        mover.availableQuestions = info.availableQuestions;
        mover.speed = info.speed;
    }

    public static void SetInfoMsg(LevelInfoMsg info) //Messages or dialogues
    {
        MessageManager.currentMessage = info.messageID;
    }

    public static Dictionary<Int32, LevelInfo> levelInfos = 
    new Dictionary<Int32, LevelInfo>{
        {6, new LevelInfo()},
        {7, new LevelInfoMsg(0)},
        {8, new LevelInfoMsg(1)},
        {9, new LevelInfoBC(globals.questionsToAsk[0], 1f, 1f, 1f)},
        {10, new LevelInfo()},
    };
}