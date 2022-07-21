using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject GameStart;
    [SerializeField]
    private GameObject ScoreText;
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
            GameStart.SetActive(true);
            ScoreText.SetActive(true);
        }
    }
}
