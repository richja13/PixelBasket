using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseBallScript : MonoBehaviour
{
    public static int Swipe;
    RectTransform thisTransform;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwipeRight()
    {
        if(Swipe < 5)
        {
            Swipe++;
            thisTransform.anchoredPosition -= new Vector2( 1000, thisTransform.anchoredPosition.y);
        }
    }

    public void SwipeLeft()
    {
        if(Swipe > 0)
        {
            Swipe--;
            thisTransform.anchoredPosition += new Vector2( 1000, thisTransform.anchoredPosition.y);
        }
      
    }
}
