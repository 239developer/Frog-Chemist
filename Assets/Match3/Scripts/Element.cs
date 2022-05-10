using UnityEngine;

public class Element
{
    public int OxidationState { get; set; }

    public void ConvertOxidationState(string oxidationState)
    {
        this.OxidationState = int.Parse(oxidationState);
    }
}
