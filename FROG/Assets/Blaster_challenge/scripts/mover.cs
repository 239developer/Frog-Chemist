using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mover : MonoBehaviour
{
    public static float speed;
    public Class parametrs;

    public Class[] quests;
    public static Class[] availableQuestions;

    public Text mytext;
    public Text ans1;
    public Text ans2;
    public Text score;

    void Start()
    {   
        if(availableQuestions != null)
            quests = availableQuestions;
        ans1=GameObject.Find("a1").GetComponent<Text>();
        ans2=GameObject.Find("a2").GetComponent<Text>();
        score=GameObject.Find("score").GetComponent<Text>();
        parametrs=quests[Random.Range(0,quests.Length)];
        mytext.text=parametrs.questionText;
    }
    void Update()
    {
        speed=Screen.height/1000.0f + globals.score*0.05f;
        ans1.text=System.Convert.ToString(globals.answer/10);
        ans2.text=System.Convert.ToString(globals.answer%10);

        transform.position += new Vector3(0,-speed,0);

        if (gameObject.transform.position.y<Screen.height/3)
        {
            Destroy(gameObject);
        }

        if (globals.answer==parametrs.ans)
        {
            globals.answer=0;
            globals.pointer=1;

            ans1.text=System.Convert.ToString(0);
            ans2.text=System.Convert.ToString(0);

            globals.score+=1;

            Destroy(gameObject);
        }

        score.text=("Score: "+System.Convert.ToString(globals.score));
    }
}

[System.Serializable]
public class Class
{
    public string questionText;
    public int ans;
    public float size;

    public Class(string text, int a, float s)
    {
        questionText = text;
        ans = a;
        size = s;
    }
}