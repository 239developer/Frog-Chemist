using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class InfoWindowManager : MonoBehaviour
{
    public Text nameText, series, mass;

    public void FillInfo(string name)
    {
        string jsonPath = $"Assets/PTable/JSONs/{name}.json";
        string jsonString = "";

        using (StreamReader sr = File.OpenText(jsonPath))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                jsonString += s;
            }
        }

        ChemicalElement CE = JsonUtility.FromJson<ChemicalElement>(jsonString);

        nameText.text = $"{CE.fullName} ({CE.symbol})";
        series.text = $"Принадлежит к группе {CE.series}";
        mass.text = $"Масса: {CE.mass} а.е.м.";

        Debug.Log(jsonString);
        Debug.Log(nameText.text);
        Debug.Log(series.text);
        Debug.Log(mass.text);
    }

    public void HideInfo()
    {
        gameObject.SetActive(false);
    }
}

[System.Serializable]
public class ChemicalElement
{
    public string symbol;
    public string fullName;
    public string series;
    public float mass;
}