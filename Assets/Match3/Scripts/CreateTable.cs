using UnityEngine;
using UnityEngine.UI;

public class CreateTable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PrefabList;

    [SerializeField]
    private int ElementsPerSide;

    [SerializeField]
    private GameObject GameBoard;

    [SerializeField]
    private Button ButtonTemplate;

    [System.NonSerialized]
    public Element[,] Elements;

    void Start()
    {
        Elements = new Element[ElementsPerSide, ElementsPerSide];
        ButtonInfo info;
        for (int i = 0; i < ElementsPerSide; i++)
        {
            for (int j = 0; j < ElementsPerSide; j++)
            {

                Elements[i, j] = PrefabList[Random.Range(0, PrefabList.Length)].GetComponent<Element>();

                ButtonTemplate.image.sprite = Elements[i, j].Sprite;
                info = ButtonTemplate.GetComponent<ButtonInfo>();
                info.PositionX = i;
                info.PositionY = j;
                ButtonTemplate.transform.localScale = new Vector2(1, 1);

                Instantiate(ButtonTemplate, GameBoard.transform);
            }
        }
    }
}
