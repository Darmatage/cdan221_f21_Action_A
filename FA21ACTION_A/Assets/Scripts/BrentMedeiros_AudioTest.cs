using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrentMedeiros_AudioTest : MonoBehaviour
{
    //one variable to hold the 1 audio source component

    public AudioSource waaa;

    void Update()
    {
        //one listener command: if (Input.GetKeyDown ("5"))
        //that play the audio (AudioSourceName.Play();}

        if (Input.GetKeyDown("5")) {waaa.Play();}
    }
}
