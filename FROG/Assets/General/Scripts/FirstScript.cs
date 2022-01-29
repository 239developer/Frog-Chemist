using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LevelManagement;

public class FirstScript : MonoBehaviour
{
    void Start()
    {
        /* init levels */
        //p.s.: read it from file asap

        levels = new List<Level>();
        levels.Add(new Level(0, "none"));
        levels.Add(new Level(0, "none"));
        levels.Add(new Level(0, "none"));
        levels.Add(new Level(0, "none"));
        levels.Add(new Level(0, "none"));
        levels.Add(new Level(0, "none"));
    }
}
