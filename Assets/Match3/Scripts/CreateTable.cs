using UnityEngine;
using UnityEngine.UI;

public class CreateTable : MonoBehaviour
{
    [SerializeField]
    private GameObject[] PrefabList;

    [SerializeField]
    public int ElementsPerSide;

    [SerializeField]
    private GameObject GameBoard;

    [SerializeField]
    private Button ButtonTemplate;

    [SerializeField]
    private GameObject GameController;

    [System.NonSerialized]
    public Element[,] Elements;

    [System.NonSerialized]
    public Button[,] ButtonsTabel;

    void Start()
    {
        Elements = new Element[ElementsPerSide, ElementsPerSide];
        ButtonsTabel = new Button[ElementsPerSide, ElementsPerSide];

        ButtonInfo info;
        for (int i = 0; i < ElementsPerSide; i++)
        {
            for (int j = 0; j < ElementsPerSide; j++)
            {
                Elements[i, j] = PrefabList[Random.Range(0, PrefabList.Length)].GetComponent<Element>();

                ButtonTemplate.image.sprite = Elements[i, j].Sprite;
                info = ButtonTemplate.GetComponent<ButtonInfo>();
                info.PositionX = j;
                info.PositionY = i;
                ButtonTemplate.transform.localScale = new Vector2(1, 1);

                ButtonsTabel[i, j] = Instantiate(ButtonTemplate, GameBoard.transform);
            }
        }

        GameController.SetActive(true);
    }
}
