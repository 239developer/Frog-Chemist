using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static int sceneID = 1;
    public Image img;
    private AsyncOperation loadingOperation;

    void Start()
    {
        loadingOperation = SceneManager.LoadSceneAsync(sceneID);
    }

    void Update()
    {
        img.fillAmount = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        if(loadingOperation.progress >= 0.9f)
        {
            loadingOperation.allowSceneActivation = true;
        }
    }
}
