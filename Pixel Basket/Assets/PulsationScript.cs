using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsationScript : MonoBehaviour
{
    public float Min;
    public float Max;
    public float Speed;
    bool ChangeSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x <= Min)
        {
            ChangeSize = true;
       
        }
        else if(transform.localScale.x >= Max)
        {
            ChangeSize = false;
           
        }

        if(ChangeSize)
        {
             transform.localScale = new Vector2(transform.localScale.x + Speed, transform.localScale.y + Speed); 
             //Vector2.MoveTowards(new Vector2(Min,Min), new Vector2(Max,Max),Speed * Time.deltaTime);
        }
        else
   {
            transform.localScale = new Vector2(transform.localScale.x - Speed, transform.localScale.y - Speed); 
            //transform.localScale = Vector2.MoveTowards(new Vector2(Max,Max),new Vector2(Min,Min), Speed * Time.deltaTime);
        }
    }
}
