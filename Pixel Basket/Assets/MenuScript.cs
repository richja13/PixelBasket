using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static bool FirstGame;
    public Image MenuPanel;
    public Color MaxColor;
    public Color MinColor;
    Color MainColor;
    public bool Open;
    float startTime;
    bool ChangeColor;
    // Start is called before the first frame update
    void Start()
    {
       Open = true;
       startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Open)
        {
           MenuPanel.rectTransform.anchoredPosition = new Vector2(0.0f,0.0f);
           // Debug.Log(MenuPanel.rectTransform.position);
        }
        else
        {
            MenuPanel.rectTransform.anchoredPosition = new Vector2(4000,4000);
        }
       
        if(ChangeColor)
        {
            //MenuPanel.color = Vector4.MoveTowards(MaxColor,MinColor, 0.3f);
            // MenuPanel.color = Vector4.Lerp(MaxColor,MinColor, 0.3f);
            var f = Mathf.Sin((Time.time - startTime) * 0.3f);
            MenuPanel.color = Color.Lerp(MaxColor,MinColor,f);
           
        }
        else
        {
            var f = (Mathf.Sin((Time.time - startTime) * 0.3f));
            //MenuPanel.color = Vector4.MoveTowards(MinColor,MaxColor, 0.3f);
            MenuPanel.color = Color.Lerp(MinColor,MaxColor,f);
        }

        if(MenuPanel.color == MaxColor)
        {
            ChangeColor = true;
        }

        if(MenuPanel.color == MinColor)
        {
            ChangeColor = false;
        }
    }

    public void StartGame()
    {
        Open = false;
        FirstGame = true;
        SkinsMenuScript.open = false;
    }

    public void OpenPanel()
    {
        if(Open)
        {
            Open = false;
            SkinsMenuScript.open = false;
        }
        else
        {
            Open = true;
            SkinsMenuScript.open = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
