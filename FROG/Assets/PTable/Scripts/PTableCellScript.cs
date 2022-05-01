using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PTableCellScript : MonoBehaviour
{
    public GameObject infoWindow = null;
    public Text numText, nameText;

    public void OpenInfo()
    {
        infoWindow.GetComponent<InfoWindowManager>().FillInfo(nameText.text);
        infoWindow.SetActive(true);
    }

    public void SetText(int num, string name)
    {
        numText.text = num.ToString();
        nameText.text = name;
    }

    public void SetColor(int index)
    {
        Color color;

        switch(index)
        {
            case 0:
                color = new Color(0.8f, 0.4f, 0.1f, 1.0f);
                break;
            case 1:
                color = new Color(0.7f, 0.7f, 0.0f, 1.0f);
                break;
            case 2:
                color = new Color(0.4f, 0.3f, 0.05f, 1.0f);
                break;
            case 3:
                color = new Color(1.0f, 0.7f, 0.75f, 1.0f);
                break;
            case 4:
                color = new Color(0.85f, 0.0f, 0.0f, 1.0f);
                break;
            case 5:
                color = new Color(0.1f, 0.1f, 0.9f, 1.0f);
                break;
            case 6:
                color = new Color(0.1f, 0.8f, 0.8f, 1.0f);
                break;
            case 7:
                color = new Color(0.4f, 1f, 0.1f, 1.0f);
                break;
            case 8:
                color = new Color(0.9f, 0.1f, 0.9f, 1.0f);
                break;
            case 9:
                color = new Color(0.67f, 0.67f, 0.67f, 1.0f);
                break;
            default:
                color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                break;
        }

        GetComponent<Image>().color = color;
    }

    public void Rotate(float value)
    {
        transform.Rotate(0.0f, 0.0f, value);
    }
}
