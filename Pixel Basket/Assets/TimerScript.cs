using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public bool GameOver;
    static public float fTime;
    public Slider TimeSlider;
    // Start is called before the first frame update
    void Start()
    {
        fTime = 8f;
        TimeSlider.maxValue = fTime;
          Debug.Log(Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
      
        if(MenuScript.FirstGame)
        {
            fTime -= Time.deltaTime;
        }
        
        TimeSlider.value = fTime;

        if(fTime <= 0)
        {
            fTime = 0;

            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = Time.timeScale * 0.002f;

            if(BallScript.Grounded)
            {
                GameOver = true;
            } 
        }
        else
        {
            Time.timeScale = 1f;
             Time.fixedDeltaTime =  0.02f;
            
        }
    }
}
