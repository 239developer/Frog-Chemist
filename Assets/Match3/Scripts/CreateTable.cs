using UnityEngine;
using UnityEngine.UI;

public class CreateTable : MonoBehaviour
{
    [SerializeField]
    private GameObject GameController;

    [SerializeField]
    private int Count;

    [SerializeField]
    private GameObject GameBoard;

    [SerializeField]
    private Button Button;

    void Start()
    {
        CreateElementTable();
        GameController.SetActive(true);
    }

    void CreateElementTable()
    {
        for (int x = 0; x < Count; x++)
        {
            for (int y = 0; y < Count; y++)
            {
                var _button = Instantiate(Button, GameBoard.transform);
                _button.name = $"Element {x * Count + y}";
            }
        }
    }
}
