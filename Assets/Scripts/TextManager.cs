using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Text nesnenizin referans�
    public TextMeshProUGUI panelScoreText; // Text nesnenizin referans�



    public int score = 0; // Skor de�eri

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "$ " + score.ToString();
        //panelScoreText.text = scoreText.text;
        panelScoreText.text = "$ " + score.ToString();
       
    }

    
}
