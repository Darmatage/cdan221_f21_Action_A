
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManagerScript : MonoBehaviour 
{
    public Animator anim;

    private bool isDoorOpen;
	
	private bool isPadOn;
	
	
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
			 gameObject.GetComponent<BoxCollider2D>().enabled = false;
		    
		    
		}
		else{
			
			  anim.SetBool ("isDoorOpen", true);
				gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
	
   
}
	

