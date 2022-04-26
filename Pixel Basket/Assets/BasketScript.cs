using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketScript : MonoBehaviour
{
    public float X;
    public float RandomY;
    
    private Vector2 Right;
    private Vector2 Left;
    public BallScript Ball;
    public static bool basketColl;
    public static bool NestColl;
    public float BasketTimer;
    public SpriteRenderer ThisRenderer;
    public SpriteRenderer Basket1;
    public SpriteRenderer Basket2;
    public SpriteRenderer Basket3;
    public ParticleSystem ScoreEffect;
    public GameObject ScorePoint;
    public AudioSource Expolsion;

    // Start is called before the first frame update
    void Start()
    {
        Right.x = 4.07f;
        Left.x = -4.07f;
        RandomY = Random.Range(-4.24f, 6.15f);
        //transform.rotation = new Quaternion(0,180,0,0);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(ScorePoint.transform.localScale.x > 0)
       {
        ScorePoint.transform.localPosition = new Vector2(ScorePoint.transform.localPosition.x, ScorePoint.transform.localPosition.y + 0.06f);
        ScorePoint.transform.localScale = new Vector2(ScorePoint.transform.localScale.x - 1.4f * Time.deltaTime,ScorePoint.transform.localScale.y - 1.4f * Time.deltaTime);
       }
       else
       {
          // ScorePoint.transform.localPosition = new Vector2(4000,4000);
           ScorePoint.transform.localScale = new Vector2(0,0);
       }
       

        if(basketColl)
        {
            BasketTimer = 1f;
            basketColl = false;

            if(NestColl)
            {
                //ScoreSystemScript.Points += 1;
            }
        }
        
        if(NestColl & BasketTimer >= 0.001f)
        {
            RandomY = Random.Range(-4.24f, 6.15f);
            Score();
           

            ScorePoint.transform.localScale = new Vector2(1.5f,1.5f);
            ScorePoint.transform.localPosition = new Vector2(transform.localPosition.x, 0);
          
            TimerScript.fTime = 8;
            NestColl = false;
            basketColl = false;
            
            StartCoroutine("FadeOut");
            if(Ball.GetComponent<Rigidbody2D>().velocity.y < -13.5f)
            {

              
                if(BallScript.Combo <= 4)
                {
                    BallScript.Combo += 1;
                    ScoreEffect.Play();
                    if(SoundManagerScript.MuteAudio)
                    {
                        Expolsion.Play();
                    }
                }
                else
                {
                    BallScript.Combo = 5;
                }
            }
            else
            {
                BallScript.Combo = 0;
            }

            ScoreSystemScript.Points += (1 + BallScript.Combo);
          
        }

        if(BasketTimer <= 0.2f && BasketTimer > 0.1f)
        {
            basketColl = false;
        }

       

        if(BasketTimer <= 0)
        {
            //basketColl = false;
            NestColl = false;
            BasketTimer = 0;
        }
        else
        {
            BasketTimer -= Time.deltaTime;
        }

        if(transform.position.x < 0)
        {
            transform.rotation = new Quaternion(0,0,0,0);
            
        }
        else
        {
            transform.rotation = new Quaternion(0,180,0,0);
           
        }

        
        if(transform.eulerAngles.y == 180)
        {
           
               Ball.VectorX = Mathf.Abs(Ball.VectorX);
        }
        else if(transform.eulerAngles.y == 0)
        {
           
          
             Ball.VectorX = -Mathf.Abs(Ball.VectorX);
        }
    }

    public void Score()
    {
       
        
        Invoke("GoToRandomPlace", 0.2f);
        
    }

    public void GoToRandomPlace()
    {
        
        RandomPlace();
         transform.position = new Vector2(X,RandomY);
    }

    public void RandomPlace()
    {
        
        if(transform.position.x == Right.x)
        {
            X = Left.x;
          //  Ball.VectorX *= -1f;
            transform.rotation = new Quaternion(0,0,0,0);
        }
        else
        {
             X = Right.x;
             transform.rotation = new Quaternion(0,180,0,0);
            // Ball.VectorX *= -1f;
        }

     

        StartCoroutine("FadeIn");
       
    }

    public void MovePoint()
    {
     
    }

     IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color b = Basket1.color;
            Color c = Basket2.color;
            Color d = Basket3.color;
            Color a = ThisRenderer.color;
            a.a = f;
            b.a = f;
            c.a = f;
            d.a = f;

            Basket1.color = b;
            Basket2.color = c;
            Basket3.color = d;
            ThisRenderer.color = a;
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            Color b = Basket1.color;
            Color c = Basket2.color;
            Color d = Basket3.color;
            Color a = ThisRenderer.color;
            a.a = f;
            b.a = f;
            c.a = f;
            d.a = f;
            Basket1.color = b;
            Basket2.color = c;
            Basket3.color = d;
            ThisRenderer.color = a;

            yield return new WaitForSeconds(0.005f);
        }
    }
}


