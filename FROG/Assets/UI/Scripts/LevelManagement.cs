using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagement : MonoBehaviour
{
    public static List<Level> levels;

    public GameObject chapterPrefab;
    public Image[] styles;

    private float borderTop = 6.0f, borderBottom = 4.5f;
    private GameObject mainCam;
    private float k;

    void Start()
    {
        mainCam = GameObject.FindWithTag("MainCamera");
        k = Screen.height / 10.0f;

        for(int i = 0; i < levels.Count / 6; i++)
        {
            GameObject ch = Instantiate(chapterPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            for(int j = 1; j <= 6; j++)
            {
                int id = i * 6 + j;
                GameObject lvl = ch.transform.Find(j.ToString()).gameObject;
                lvl.GetComponentInChildren<Text>().text = id.ToString();
                lvl.transform.Find("stars").gameObject.GetComponent<Image>().fillAmount = levels[id - 1].stars / 3.0f;
                
                Image img;
                switch(levels[id - 1].type)
                {
                    default:
                        img = styles[0];
                        break;
                } //continue here
            }
        }
    }

    void Update()
    {
        /* --- camera movement --- */

        float moveCamY = 0.0f;
        if(Input.touchCount > 0)
            moveCamY = - Input.GetTouch(0).deltaPosition.y / k;
        mainCam.transform.Translate(0.0f, moveCamY, 0.0f);

        float y = mainCam.transform.position.y;
        if(y > borderTop)
            mainCam.transform.Translate(0.0f, - y + borderTop, 0.0f);
        if(y < borderBottom)
            mainCam.transform.Translate(0.0f, - y + borderBottom, 0.0f);
    }
}

[System.Serializable]
public class Level          //carries info about existing levels
{
    public int stars = 0;
    public string type = "none";
    
    public Level() {}
    public Level(int s, string t)
    {
        stars = s;
        type = t;
    }
}
/* types of levels: */
//0 none  
//1 match3
//2 blaster
//3 prac
//4 bonus
//5 theory/dialog