using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    private Element[,] Elements;

    private GameObject button1 = null, button2 = null;
    void Start()
    {
        Elements = gameObject.GetComponent<CreateTable>().Elements;
    }

    void Update()
    {
        if (button1 != null && button2 != null)
        {
            ButtonInfo info1 = button1.GetComponent<ButtonInfo>();
            ButtonInfo info2 = button2.GetComponent<ButtonInfo>();

            if (IsSwapeble(info1, info2))
            {
                SwapElements(info1, info2);
                SwapButtons(button1, button2);
            }
            button1 = null;
            button2 = null;
        }
    }

    private bool IsSwapeble(ButtonInfo info1, ButtonInfo info2)
    {
        return Mathf.Sqrt(Mathf.Pow(info1.PositionX - info2.PositionX, 2) 
            + Mathf.Pow(info1.PositionY - info2.PositionY, 2)) <= 1.1f;
    }

    private void SwapButtons(GameObject button1, GameObject button2)
    {
        Sprite tmpButton = button1.GetComponent<Image>().sprite;
        button1.GetComponent<Image>().sprite = button2.GetComponent<Image>().sprite;
        button2.GetComponent<Image>().sprite = tmpButton;
    }

    private void SwapElements(ButtonInfo info1, ButtonInfo info2)
    {
        Element tmpElemement = Elements[info1.PositionX, info1.PositionY];
        Elements[info1.PositionX, info1.PositionY] = Elements[info2.PositionX, info2.PositionY];
        Elements[info2.PositionX, info2.PositionY] = tmpElemement;
    }

    public void ButtonClick()
    {
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;

        if (currentButton.GetComponent<ButtonInfo>() != null)
        {
            if (button1 == null)
            {
                button1 = currentButton;
            }
            else
            {
                button2 = currentButton;
            }
        }
    }
}
