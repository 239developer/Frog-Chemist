using UnityEngine;

public class Element
{
    public int OxidationState { get; set; }

    public GameObject Button { get; set; }

    public void ConvertOxidationState(string oxidationState)
    {
        this.OxidationState = int.Parse(oxidationState);
    }

    public Element(GameObject button)
    {
        Button = button;
    }
}
