using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Image GameOverPanel;
    public TimerScript Time1;
    public Button RestartButton;
    BallScript ball1;
    BasketScript basket;
    public Animator ChangeScene;
    // Start is called before the first frame update
    void Start()
    {
        ball1 = GameObject.Find("Ball").GetComponent<BallScript>();
        basket = GameObject.Find("Basket").GetComponent<BasketScript>();
        GameOverPanel = GetComponent<Image>();
        GameOverPanel.rectTransform.anchoredPosition = new Vector2(0,4000);
        
  
    }

    // Update is called once per frame
    void Update()
    {
        if(Time1.GameOver == true)
        {
            GameOverPanel.rectTransform.anchoredPosition = Vector2.MoveTowards(new Vector2(0,0), new Vector2(0,0), 2.5f);
        }


        if(AdsControllerScript.RewardedVideo)
        {
            Debug.Log(AdsControllerScript.RewardedVideo);
            Time1.GameOver = false;
            GameOverPanel.rectTransform.anchoredPosition = new Vector2(0,4000);
            TimerScript.fTime = 8f;
            AdsControllerScript.RewardedVideo = false;
            ball1.RestartBall();
            basket.RandomPlace();
        }
    }

    public void RestartScene()
    {
        
        Time1.GameOver = false;
        GameOverPanel.rectTransform.anchoredPosition = new Vector2(0,4000);
        ScoreSystemScript.Points = 0;
        TimerScript.fTime = 8f;
        ball1.RestartBall();
        basket.RandomPlace();
        
    }


    public void resurrection()
    {   
        
    }

    public void ChangeSceneFunction()
    {
        ChangeScene.SetTrigger("Start");
    }
}
