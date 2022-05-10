using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private int CountPerSide;

    [SerializeField]
    private Image[] Images;

    private Element[,] Elements;

    void Start()
    {
        Elements = new Element[CountPerSide, CountPerSide];

        for (int i = 0; i < CountPerSide; i++)
        {
            for (int j = 0; j < CountPerSide; j++)
            {
                Elements[i, j] = new Element(GameObject.Find($"Element {i * CountPerSide + j}"));
                Image image = Images[Random.Range(0, Images.Length)];
                Elements[i, j].Button.GetComponent<Image>().sprite = image.sprite;

                Elements[i, j].ConvertOxidationState(image.name[image.name.Length - 1].ToString());
            }
        }
    }

    private void SwapElements(ref Element element1, ref Element element2)
    {
        Element _tmpElement = element1;
        element1 = element2;
        element2 = _tmpElement;
    }

    void Update()
    {
        
    }
}
