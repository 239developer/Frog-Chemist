using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InfoWindowManager : MonoBehaviour
{
    public Text info, heading;

    public void FillInfo(int element)
    {
        string jsonString = JSONstore.elems[element];

        ChemicalElement CE = JsonUtility.FromJson<ChemicalElement>(jsonString);

        heading.text = $"{CE.name} ({CE.symbol})";
        info.text = $"Атомное число: {CE.number}" + "\n" + $"Атомная масса: {CE.mass} а.е.м." + "\n" + $"Принадлежит к {CE.group} группе" + "\n" + $"Температура кипения: {CE.bp}°C" + "\n" + $"Температура плавления: {CE.mp}°C" + "\n" + $"Степени окисления: {CE.oxidationStates}";
    }

    public void HideInfo()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        var rt = gameObject.GetComponent<RectTransform>();
        rt.offsetMax = Vector2.one * 0.5f * Math.Min(Screen.height, Screen.width);
        rt.offsetMin = Vector2.one * -0.5f * Math.Min(Screen.height, Screen.width);
    }
}

[System.Serializable]
public class ChemicalElement
{
    public string name;
    public string symbol;
    public string phase;
    public string number;
    public string group;
    public string mp;
    public string bp;
    public string oxidationStates;
    public string mass;
}