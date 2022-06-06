using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLayoutFiller : MonoBehaviour
{
    public static int firstLevel = 1;
    public static GameObject[] levelIcons; //its always 5 of these
    public GameObject[] anchors; //and 7 of these
    public GameObject connectLine;
    public GameObject basicIcon;

    private GameObject[] levelButtons, connectionLines;
    private GameObject canvas;

    public void Fill()
    {
        levelButtons = new GameObject[5];
        connectionLines = new GameObject[6];
        canvas = GameObject.FindWithTag("Main Canvas");
        if(levelIcons == null)
        {
            levelIcons = new GameObject[5];
            for(int i = 0; i < 5; i++)
            {
                levelIcons[i] = basicIcon;
            }
        }

        for (int i = 0; i < 6; i++) //6 is for anchors.Length - 1
        {
            GameObject line = GameObject.Instantiate(connectLine, canvas.transform);
            Vector3 pos0 = anchors[i].transform.position;
            Vector3 pos1 = anchors[i + 1].transform.position;
            ObjectConnector.ConnectTwo(line, pos0, pos1);
        }

        for (int i = 0; i < 5; i++) //5 is for levelIcons.Length
        {
            GameObject icon = levelIcons[i];
            Vector3 position = anchors[i + 1].transform.position;
            Quaternion rotation = icon.transform.rotation;
            Transform parent = canvas.transform;
            
            levelButtons[i] = GameObject.Instantiate(icon, position, rotation, parent);
            levelButtons[i].GetComponentInChildren<Text>().text = (firstLevel + i).ToString();
        }
    }

    void Start()
    {
        Fill();
    }
}
