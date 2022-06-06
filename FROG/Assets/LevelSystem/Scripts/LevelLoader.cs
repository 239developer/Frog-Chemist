using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelLoader : MonoBehaviour
{
    // loads the level whose number is indicated in the button ->
    public void LoadLevelByButton(GameObject button)
    {
        int id = Convert.ToInt32(button.GetComponentInChildren<Text>().text);
        
        Debug.Log(id);
    }   
}
