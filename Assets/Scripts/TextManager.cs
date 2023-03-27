using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Text nesnenizin referansý
    public TextMeshProUGUI panelScoreText; // Text nesnenizin referansý



    public int score = 0; // Skor deðeri

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
