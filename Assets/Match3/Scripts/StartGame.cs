using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject GameController;
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.S))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            GameController.SetActive(true);
        }
    }
}
