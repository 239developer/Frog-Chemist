using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MessageManager : MonoBehaviour
{
    public static int currentMessage = 0;
    public GameObject messageObject;
    public GameObject[] messageObjects;

    public void FinishDialogue(int scene)
    {
        LevelManager.levelInfos[LevelManager.currentLevel].isFinished = true;
        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        if(messageObject != null) GameObject.Destroy(messageObject);
        GameObject instance = messageObjects[currentMessage];
        Transform parent = GameObject.FindWithTag("Main Canvas").transform;
        messageObject = GameObject.Instantiate(instance, parent);
    }
}
