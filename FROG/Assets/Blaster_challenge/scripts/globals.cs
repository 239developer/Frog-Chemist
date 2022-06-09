using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globals
{
    public static int answer;
    public static int pointer = 1;
    public static int score=0;

    public static Class[][] questionsToAsk = 
    {
        new Class[]
        {
            new Class("Na Cl", 11, 10),
            new Class("H O", 21, 10),
            new Class("K O", 21, 10),
            new Class("Li F", 11, 10),
            new Class("K Cl", 11, 10),
            new Class("Ca O", 11, 10),
        },
    };
}
