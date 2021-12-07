using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
	
	public AudioClip[] clipArray;
	public AudioSource effectSource;
	private int clipIndex;
	
	
	   void Update(){
                 if (Input.GetButtonDown("Attack")){
              PlayRandom();
       }
			}
	
 void PlayRandom()
{
    clipIndex = Random.Range(0, clipArray.Length);
    effectSource.PlayOneShot(clipArray[clipIndex]);
}
  
}
