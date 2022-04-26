using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGhostScript : MonoBehaviour
{
     public float ModfiyForce;
    Rigidbody2D rb;
    public float VectorX;
    BallScript ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball").GetComponent<BallScript>();
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        VectorX = ball.VectorX;
        ModfiyForce = ball.ModfiyForce;

          if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector2(0,0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(0,0);
            rb.AddForce(new Vector2(VectorX,2.4f) * ModfiyForce, ForceMode2D.Force);
        }
    }
}
