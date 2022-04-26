using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShadowScript : MonoBehaviour
{
    public GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {
        Ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Ball.transform.position.x, transform.position.y);
        transform.localScale = new Vector2( 5.5f - (Ball.transform.position.y / 6f), 5.5f - (Ball.transform.position.y / 6f));
    }
}
