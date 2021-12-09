using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
	public GameHandler gameHandler;
	public AudioClip[] clipArray;
	public AudioSource effectSource;
	private int clipIndex;
	
	
	   void Update(){
                 if (Input.GetButtonDown("Attack")&& GameHandler.GameisPaused==false){
              PlayRandom();
       }
			}
	
 void PlayRandom()
{
    clipIndex = Random.Range(0, clipArray.Length);
    effectSource.PlayOneShot(clipArray[clipIndex]);
}
  
}
