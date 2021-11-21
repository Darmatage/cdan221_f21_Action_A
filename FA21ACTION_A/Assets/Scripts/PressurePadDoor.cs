using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadDoor : MonoBehaviour
{
	
	public bool onPlate = false;
	
    public void OnCollisionEnter2D(Collision2D other) {
              if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") { //also add or enemey tag
                    
					onPlate=true;
					
              }
			  
	}
	
	  public void OnCollisionExit2D(Collision2D other) {
              if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") { //also add or enemey tag
                    
					onPlate=false;
					
              }
			  
	} 
}
