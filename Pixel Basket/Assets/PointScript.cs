using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointScript : MonoBehaviour
{
     public GameObject Obj;
 
    Camera mCamera;
    private RectTransform rt;
    Vector2 pos;
  
    // Start is called before the first frame update
    void Start()
    {
        mCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
        rt = GetComponent<RectTransform> ();
    }

    // Update is called once per frame
    void Update()
    {
        var Score = 1 + BallScript.Combo;
        this.gameObject.transform.localScale = new Vector2(Obj.transform.localScale.x, Obj.transform.localScale.y);
        this.gameObject.GetComponent<Text>().text = "+" + Score;
        if (Obj)
        {
            pos = RectTransformUtility.WorldToScreenPoint (mCamera, Obj.transform.position);
            rt.position = pos;
        }
        else
        {
            Debug.LogError (this.gameObject.name + ": No Object Attached (TrackObject)");
        }
    }
}
