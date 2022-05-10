using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int CountPerSide;

    [SerializeField]
    private Image[] Images;

    private Element[,] Elements;

    private GameObject[,] Buttons;
    void Start()
    {
        Buttons = new GameObject[CountPerSide, CountPerSide];
        Elements = new Element[CountPerSide, CountPerSide];

        for (int i = 0; i < CountPerSide; i++)
        {
            for (int j = 0; j < CountPerSide; j++)
            {
                Buttons[i, j] = GameObject.Find($"Element {i * CountPerSide + j}");
                Elements[i, j] = new Element();
                Image image = Images[Random.Range(0, Images.Length)];
                Buttons[i, j].GetComponent<Image>().sprite = image.sprite;
                Buttons[i, j].GetComponent<Button>().onClick.AddListener(Click);
                Elements[i, j].ConvertOxidationState(image.name[image.name.Length - 1].ToString());
            }
        }
    }

    private void SwapElements(ref Element element1, ref Element element2)
    {
        Element _tmpElement1 = element1, _tmpElement2 = element2;
        element1 = _tmpElement2;
        element2 = _tmpElement1;
    }

    private void SwapButtons(GameObject button1, GameObject button2)
    {
        Sprite _tmpButton1 = button1.GetComponent<Image>().sprite, _tmpButton2 = button2.GetComponent<Image>().sprite;
        button1.GetComponent<Image>().sprite = _tmpButton2;
        button2.GetComponent<Image>().sprite = _tmpButton1;
    }
    private ElementIndex GetIndex(GameObject element)
    {
        ElementIndex elementIndex = null;

        for (int i = 0; i < CountPerSide; i++)
        {
            for (int j = 0; j < CountPerSide; j++)
            {
                if (element.name == Buttons[i, j].name)
                {
                    elementIndex = new ElementIndex();
                    elementIndex.Row = i;
                    elementIndex.Column = j;
                    break;
                }
            }

            if (elementIndex != null)
            {
                break;
            }
        }

        return elementIndex;
    }

    private GameObject _selectedButton1 = null;
    private GameObject _selectedButton2 = null;

    ElementIndex elementIndex1 = null;
    ElementIndex elementIndex2 = null;

    private void Click()
    {
        if (_selectedButton1 == null)
        {
            _selectedButton1 = EventSystem.current.currentSelectedGameObject;
        }
        else if(_selectedButton2 == null)
        {
            _selectedButton2 = EventSystem.current.currentSelectedGameObject;

            elementIndex1 = GetIndex(_selectedButton1);
            elementIndex2 = GetIndex(_selectedButton2);
            if (elementIndex1 != null && elementIndex2 != null && IsInside(elementIndex1.Row, elementIndex1.Column, elementIndex2.Row, elementIndex2.Column))
            {
                SwapElements(ref Elements[elementIndex1.Row, elementIndex1.Column], ref Elements[elementIndex2.Row, elementIndex2.Column]);
                SwapButtons(Buttons[elementIndex1.Row, elementIndex1.Column], Buttons[elementIndex2.Row, elementIndex2.Column]);
            }
            elementIndex1 = null;
            elementIndex2 = null;

            _selectedButton1 = null;
            _selectedButton2 = null;
        }
    }

    private bool IsInside(int x1, int y1, int x2, int y2)
    {
        return Mathf.Abs(x1 - x2) <= 1 && Mathf.Abs(y1 - y2) <= 1;
    }

    void Update()
    {
        
    }
}

class ElementIndex
{
    public int Row { get; set; }

    public int Column { get; set; }
}
