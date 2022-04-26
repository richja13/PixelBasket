using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    public static bool MuteAudio;
    public AudioSource buttonSound;
    public Sprite MuteSprite;
    public Sprite UnMuteSprite;
    public Button MuteButton;


    // Start is called before the first frame update
    void Start()
    {
        MuteAudio = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(MuteAudio)
        {
            MuteButton.GetComponent<Image>().sprite = UnMuteSprite;
        }
        else
        {
            MuteButton.GetComponent<Image>().sprite = MuteSprite;
        }

    }

    public void Mute()
    {
        if(MuteAudio)
        {
            MuteAudio = false;
        }
        else
        {
            MuteAudio = true;
        }
    }

    public void ButtonClick()
    {
        if(MuteAudio)
        {
            buttonSound.Play();
        }
    }
}
