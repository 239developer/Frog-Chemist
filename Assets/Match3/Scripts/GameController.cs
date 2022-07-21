using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Text Score;

    [SerializeField]
    private GameObject GameStart;

    [SerializeField]
    private Element[] ElementTemplates;

    private Element[,] Elements;

    private Button[,] ButtonsTable;

    private uint LocaleScore = 0;

    private int ElementsPerSide;

    private GameObject _button1 = null, _button2 = null;

    private List<ButtonInfo> MovedElements;

    void Start()
    {
        Elements = GameStart.GetComponent<CreateTable>().Elements;
        ButtonsTable = GameStart.GetComponent<CreateTable>().ButtonsTabel;
        ElementsPerSide = GameStart.GetComponent<CreateTable>().ElementsPerSide;
        MovedElements = new List<ButtonInfo>();

        for (int i = 0; i < ElementsPerSide; i++)
        {
            for (int j = 0; j < ElementsPerSide; j++)
            {
                ButtonInfo startInfo = new ButtonInfo { PositionX = i, PositionY = j };

                MatchAndClear(startInfo);
            }
        }

        LocaleScore = 0;
        Score.text = LocaleScore.ToString();
    }

    void Update()
    {
        if (_button1 != null && _button2 != null)
        {
            ButtonInfo info1 = _button1.GetComponent<ButtonInfo>();
            ButtonInfo info2 = _button2.GetComponent<ButtonInfo>();

            if (IsSwapeble(info1, info2))
            {
                SwapElements(ref info1, ref info2);
                SwapButtons(_button1, _button2);
                MatchAndClear(info1);
                MatchAndClear(info2);

                if (MovedElements.Count == 0)
                {
                    SwapElements(ref info1, ref info2);
                    SwapButtons(_button1, _button2);
                }

                Score.text = LocaleScore.ToString();
            }
            
            _button1 = null;
            _button2 = null;
        }
    }

    private void MatchAndClear(ButtonInfo info)
    {
        List<List<ButtonInfo>> ElementsPositions = new List<List<ButtonInfo>>();

        ElementsPositions.Add(Match(info, DirectionCode.Up));
        ElementsPositions.Add(Match(info, DirectionCode.Down));
        ElementsPositions.Add(Match(info, DirectionCode.Left));
        ElementsPositions.Add(Match(info, DirectionCode.Right));

        if (ElementsPositions[0].Count == ElementsPositions[2].Count && ElementsPositions[0].Count == 3)
        {
            ClearElements(ElementsPositions[0]);
            ClearElements(ElementsPositions[2]);
        }
        else if (ElementsPositions[0].Count == ElementsPositions[3].Count && ElementsPositions[0].Count == 3)
        {
            ClearElements(ElementsPositions[0]);
            ClearElements(ElementsPositions[3]);
        }
        else if (ElementsPositions[1].Count == ElementsPositions[3].Count && ElementsPositions[1].Count == 3)
        {
            ClearElements(ElementsPositions[1]);
            ClearElements(ElementsPositions[3]);
        }
        else if (ElementsPositions[1].Count == ElementsPositions[2].Count && ElementsPositions[1].Count == 3)
        {
            ClearElements(ElementsPositions[1]);
            ClearElements(ElementsPositions[2]);
        }

        ClearLine(ElementsPositions[0], ElementsPositions[1]);
        ClearLine(ElementsPositions[2], ElementsPositions[3]);

        if (MovedElements.Count != 0)
        {
            int _count = MovedElements.Count;
            for (int i = 0; i < _count; i++)
            {
                try
                {
                    ButtonInfo _tmp = MovedElements[0];
                    MovedElements.RemoveAt(0);
                    MatchAndClear(_tmp);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    continue;
                }
            }
        }
    }

    private void ClearElements(List<ButtonInfo> elementsPositions)
    {
        for (int i = 0; i < elementsPositions.Count; i++)
        {
            Elements[elementsPositions[i].PositionY, elementsPositions[i].PositionX] = ElementTemplates[Random.Range(0, ElementTemplates.Length)];
            ButtonsTable[elementsPositions[i].PositionY, elementsPositions[i].PositionX].image.sprite = Elements[elementsPositions[i].PositionY, elementsPositions[i].PositionX].Sprite;
            LocaleScore++;
            MovedElements.Add(elementsPositions[i]);
        }
    }

    private void ClearLine(List<ButtonInfo> elementsPositions1, List<ButtonInfo> elementsPositions2)
    {
        List<ButtonInfo> newElementsPosition = new List<ButtonInfo>();

        elementsPositions2.RemoveAt(0);

        if (elementsPositions1.Count + elementsPositions2.Count >= 3)
        {
            int j = 0;
            for (int i = 0; i < elementsPositions1.Count && j < 5; i++, j++)
            {
                newElementsPosition.Add(elementsPositions1[i]);
            }
            for (int i = 0; i < elementsPositions2.Count && j < 5; i++, j++)
            {
                newElementsPosition.Add(elementsPositions2[i]);
            }

            ClearElements(newElementsPosition);
        }
    }

    private List<ButtonInfo> Match(ButtonInfo info, DirectionCode directionCode)
    {
        List<ButtonInfo> position = new List<ButtonInfo>();
        ButtonInfo nextInfo = new ButtonInfo();

        position.Add(info);


        switch (directionCode)
        {
            case DirectionCode.Up:
                nextInfo.PositionX = info.PositionX;
                nextInfo.PositionY = info.PositionY - 1;
                break;
            case DirectionCode.Down:
                nextInfo.PositionX = info.PositionX;
                nextInfo.PositionY = info.PositionY + 1;
                break;
            case DirectionCode.Left:
                nextInfo.PositionX = info.PositionX - 1;
                nextInfo.PositionY = info.PositionY;
                break;
            case DirectionCode.Right:
                nextInfo.PositionX = info.PositionX + 1;
                nextInfo.PositionY = info.PositionY;
                break;
        }

        //Check, if positions is in range of array`s indexes
        if (nextInfo.PositionX < ElementsPerSide && nextInfo.PositionX >= 0 && nextInfo.PositionY < ElementsPerSide && nextInfo.PositionY >= 0)
        {
            if (Elements[info.PositionY, info.PositionX].OxidationState == Elements[nextInfo.PositionY, nextInfo.PositionX].OxidationState)
            {
                List<ButtonInfo> nextMatches = Match(nextInfo, directionCode);
                foreach (var pos in nextMatches)
                {
                    position.Add(pos);
                }
            }
        }

        return position;
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

    private void SwapElements(ref ButtonInfo info1, ref ButtonInfo info2)
    {
        Element tmpElemement = Elements[info1.PositionY, info1.PositionX];
        Elements[info1.PositionY, info1.PositionX] = Elements[info2.PositionY, info2.PositionX];
        Elements[info2.PositionY, info2.PositionX] = tmpElemement;

        ButtonInfo tmpInfo = info1;
        info1 = info2;
        info2 = tmpInfo;
    }

    public void ButtonClick()
    {
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;

        if (currentButton.GetComponent<ButtonInfo>() != null)
        {
            if (_button1 == null)
            {
                _button1 = currentButton;
            }
            else
            {
                _button2 = currentButton;
            }
        }
    }

    enum DirectionCode
    {
        Up,
        Down,
        Left,
        Right
    }
}