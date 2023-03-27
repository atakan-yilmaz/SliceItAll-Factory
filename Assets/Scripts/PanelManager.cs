using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject finishPanel; 

    public bool isPlay = false;

    private void Start()
    {
        if (isPlay == false)
        {
            startPanel.SetActive(true);
        }


    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        isPlay = true;
    }

    public void ContinueGame()
    {
        finishPanel.SetActive(false);
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = activeSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
