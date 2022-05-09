using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManager;
    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.S))
        {
            gameObject.SetActive(false);
            GameManager.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
