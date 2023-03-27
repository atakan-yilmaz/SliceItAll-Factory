using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Text nesnenizin referans�
    public TextMeshProUGUI panelScoreText; // Text nesnenizin referans�
    public TextMeshProUGUI levelText; // Text nesnenizin referans�



    public int score = 0; // Skor de�eri

    // Start is called before the first frame update
    void Start()
    {
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
       

        scoreText.text = "$ " + score.ToString();
        //panelScoreText.text = scoreText.text;
        panelScoreText.text = "$ " + score.ToString();
       
    }

    
}
