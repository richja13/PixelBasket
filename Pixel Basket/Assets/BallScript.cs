using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public float ModfiyForce;
    Rigidbody2D rb;
    public BasketScript basket;
    public float VectorX;
    public TimerScript Timer; 
    public static bool Grounded;
    public static int Combo;
    public GameObject Fire;
    public GameObject Smoke;
    public AudioSource TapAudio;
    public AudioSource HitAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        VectorX = 0.5f;
        rb = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
       // this.gameObject.GetComponent<SpriteRenderer>().sprite = SkinsMenuScript.Skin;
        //CheckBalls();

        this.gameObject.GetComponent<SpriteRenderer>().sprite = SkinsMenuScript.Skin;

        if(Combo > 0)
        {
            Smoke.SetActive(true);
        }
        else
        {
            Smoke.SetActive(false);
        }

        if(Combo > 1)
        {
            Fire.SetActive(true);
        }
        else
        {
            Fire.SetActive(false);
        }

        if(!MenuScript.FirstGame)
        {
            transform.position = new Vector2(0,0);
        }

        if (Input.GetMouseButtonDown(0) && TimerScript.fTime > 0)
        {
            rb.velocity = new Vector2(0,0);
            rb.AddForce(new Vector2(VectorX,2.4f) * ModfiyForce, ForceMode2D.Force);

            if(SoundManagerScript.MuteAudio == true)
            {
                TapAudio.Play();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Kosz")
        {
            BasketScript.basketColl = true;
            BasketScript.NestColl = false;
            
        }

        if(collision.gameObject.tag == "Nest")
        {   
            BasketScript.NestColl = true;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.velocity.y < 2 && collision.gameObject.tag == "Ground")
        {
            //HitAudio.Play();
        }
        else
        {
            if(SoundManagerScript.MuteAudio)
            {
                HitAudio.Play();
            }
        }

        if(collision.gameObject.tag == "Ground")
        {
            if(TimerScript.fTime <= 0)
            {
                Timer.GameOver = true;
            }
        }
    }

    public void RestartBall()
    {
        transform.position = new Vector2(0,0);
    }
}
