using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystemScript : MonoBehaviour
{
    public Text ScoreText;
    public Text GameOverScore;
    public Text GameOverHighScore;
    public static int Points;
    public static int Highscore;
    // Start is called before the first frame update
    void Start()
    {
        Highscore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if(Points > Highscore)
        {
            Highscore = Points;
        }

        PlayerPrefs.SetInt("Highscore", Highscore);
        ScoreText.text = "" + Points;
        GameOverScore.text = "SCORE: " + Points;
        GameOverHighScore.text = "HIGHSCORE: " + Highscore;
    }
}
