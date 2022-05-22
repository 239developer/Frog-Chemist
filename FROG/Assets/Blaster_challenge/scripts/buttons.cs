using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class buttons : MonoBehaviour
{
    public string letter;
    public int plus;
    public float a;
    public bool press;
    public void pressed()
    {
        press=true;
        a=Time.time;
    }
    public int pointer = 1;
    void Update()
    {
        pointer=globals.pointer;
        if(press)
        {
            if(Time.time-a>0.05)
            {
                press=false;
                if (gameObject.name != "del")
                {
                    plus=System.Convert.ToInt32(gameObject.name);
                    if (pointer==1)
                    {
                        globals.answer=plus*10;
                        pointer=2;
                        globals.pointer=pointer;
                    }
                    else
                    {
                        globals.answer += plus;
                    }
                }
                else
                {
                    pointer = 1;
                    globals.answer=globals.answer/10;
                    globals.pointer=1;
                }
                
                UnityEngine.Debug.Log(globals.answer);
                UnityEngine.Debug.Log(pointer);
            }
        }
    }
}
