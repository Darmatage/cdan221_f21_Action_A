
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerScript : MonoBehaviour 
{
    public Animator anim;

    private bool isDoorOpen;
	
	private bool isPadOn;
	
	public float timer =0.05f;  
	
    public PressurePadDoor myPressurePadDoor;
	



    void Start()
    {
        anim.SetBool ("isDoorOpen", false);
        isDoorOpen = false;
		
		
    }
	
	

    void Update()
    {
        isDoorOpen = anim.GetBool ("isDoorOpen");
        isPadOn = myPressurePadDoor.onPlate;
		if (isPadOn==true) 
        {
			anim.SetBool ("isDoorOpen", false);
			//want to wait for 2 seconds here
			StartCoroutine(myDelay());
			//gameObject.GetComponent<BoxCollider2D>().enabled = false;
		    
		    
		}
		else{
			
			  anim.SetBool ("isDoorOpen", true);
				gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
	
	IEnumerator myDelay(){
     yield return new WaitForSeconds(timer); //will delay about two seconds. Set this number as desired
	  Debug.Log("1 second past");
     gameObject.GetComponent<BoxCollider2D>().enabled = false;
}

   
}
	

