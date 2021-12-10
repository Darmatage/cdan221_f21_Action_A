using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAudio : MonoBehaviour
{
	public AudioSource mushroomSFX;
	public GameHandler gameHandlerObj;
    // Start is called before the first frame update
    void Start()
    {
		            if (GameObject.FindWithTag("GameHandler") != null){
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            }
        
    }

    public void OnCollisionEnter2D(Collision2D other) {
              if (other.gameObject.tag == "Player") {
                  mushroomSFX.Play();   
                     //other.transform.position = new Vector2(backToStart.position.x, backToStart.position.y);
              }
	}
}
