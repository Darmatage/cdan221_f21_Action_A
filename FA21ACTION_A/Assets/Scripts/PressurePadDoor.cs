using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadDoor : MonoBehaviour
{
	public Animator anim;
	
	public bool onPlate = false;
	
	 void Start(){
		anim = GetComponentInChildren<Animator>();
		
		
      
    }
	
    public void OnCollisionEnter2D(Collision2D other) {
              if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") { //also add or enemey tag
                    
					onPlate=true;
					anim.SetTrigger("ButtonPushedDown");
					anim.SetBool("isButtonDown", true);
					
              }
			  
	}
	
	  public void OnCollisionExit2D(Collision2D other) {
              if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") { //also add or enemey tag
                    
					onPlate=false;
					anim.SetTrigger("ButtonGoingUp");
					anim.SetBool("isButtonDown", false);
					
              }
			  
	} 
}
