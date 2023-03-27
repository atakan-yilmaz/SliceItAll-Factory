using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject startPanel; // Baþlangýç paneli
    public GameObject finishPanel; // Baþlangýç paneli

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
        SceneManager.LoadScene(activeSceneIndex + 1);
    }
}
