using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PTableCellScript : MonoBehaviour
{
    public Text numText, nameText;

    public void SetText(int num, string name)
    {
        numText.text = num.ToString();
        nameText.text = name;
    }
}
