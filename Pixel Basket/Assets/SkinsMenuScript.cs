using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsMenuScript : MonoBehaviour
{
    public static bool open;
    RectTransform rect;
    public static Sprite Skin;
    public  List<Button> SkinSelectButton;
    int a;
    public GameObject Menu;
  
    // Start is called before the first frame update
    void Start()
    {
        open = true;
        rect = GetComponent<RectTransform>();
       // Skin = SkinSelectButton[3].GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
       // Skin = SkinSelectButton[ChooseBallScript.Swipe].GetComponent<Image>().sprite;
        CheckBalls();

        //this.gameObject.GetComponent<Image>().color = Menu.GetComponent<Image>().color;
       
        if(open)
        {
            rect.anchoredPosition = new Vector2(33,257);
        }
        else
        {
            rect.anchoredPosition = new Vector2(0,4000);
        }

        //SelectSkin();
        
    }

      public void CheckBalls()
    {
       
        
        switch(ChooseBallScript.Swipe)
        {
            case 1:
                if(ScoreSystemScript.Highscore >= 50) Skin = SkinSelectButton[ChooseBallScript.Swipe].GetComponent<Image>().sprite; else NormalBall();
            break;


             case 2:
                  if(ScoreSystemScript.Highscore >= 100) Skin = SkinSelectButton[ChooseBallScript.Swipe].GetComponent<Image>().sprite; else NormalBall();
            break;


             case 3:
                  if(ScoreSystemScript.Highscore >= 250)  {
                    Skin = SkinSelectButton[ChooseBallScript.Swipe].GetComponent<Image>().sprite;

                } 
                else 
                { 
                    NormalBall();
                }
            break;


             case 4:

                if(ScoreSystemScript.Highscore >= 400) 
                {
                    Skin = SkinSelectButton[ChooseBallScript.Swipe].GetComponent<Image>().sprite;

                } 
                else 
                { 
                    NormalBall();
                }

            break;


            case 5:
                 if(ScoreSystemScript.Highscore >= 650)  {
                    Skin = SkinSelectButton[ChooseBallScript.Swipe].GetComponent<Image>().sprite;

                } 
                else 
                { 
                    NormalBall();
                }
            break;

             case 0:
                  if(ScoreSystemScript.Highscore >= 0) 
                  Skin = SkinSelectButton[ChooseBallScript.Swipe].GetComponent<Image>().sprite;
                   else NormalBall();
            break;
          
            
          
        }
    }

     void NormalBall()
    {
        Skin = SkinSelectButton[0].GetComponent<Image>().sprite;
    }


    public void ClosePanel()
    {
        if(open)
        {
            open = false;
        }
        else
        {
            open = true;
        }
    }

    void SelectSkin()
    {
       /* for(int i = 0;i < SkinSelectButton.ToArray().Length; i++)
        { 
            Debug.Log(a + "długość");
            a = i;
            var c = a;
            SkinSelectButton[i].onClick.AddListener(() => Skin = SkinSelectButton[c].GetComponent<Image>().sprite);
        }*/
      

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
           //   Skin = collision.gameObject.GetComponent<Image>().sprite;
           //   Debug.Log(collision.gameObject.name);
        }
    }
}
