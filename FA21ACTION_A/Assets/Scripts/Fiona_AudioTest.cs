using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiona_AudioTest : MonoBehaviour{
	
	public AudioSource squich1;
	//public AudioSource squich1;
	//public AudioSource squich1;
	//public AudioSource squich1;
   

    // Update is called once per frame
    void Update()
    {
		
		if (Input.GetKeyDown("5")){squich1.Play();}
        
    }
}
