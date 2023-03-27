using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject startPanel; // Baþlangýç paneli

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
}
