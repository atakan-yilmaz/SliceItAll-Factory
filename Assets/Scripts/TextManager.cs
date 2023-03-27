using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI panelScoreText; 
    public TextMeshProUGUI levelText; 

    public int money = 0; 

   
    void Start()
    {

        money = PlayerPrefs.GetInt("score", 0);

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                levelText.text = "LEVEL 1";
                break;
            case 1:
                levelText.text = "LEVEL 2";
                break;
            case 2:
                levelText.text = "LEVEL 3";
                break;
            default:
                levelText.text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {      
        scoreText.text = "$ " + money.ToString();
        panelScoreText.text = "$ " + money.ToString();   
    }

    void OnDestroy()
    {
        
        PlayerPrefs.SetInt("score", money);
        PlayerPrefs.Save();
    }

}
