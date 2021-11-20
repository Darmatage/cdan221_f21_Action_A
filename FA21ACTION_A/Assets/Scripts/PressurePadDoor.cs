using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePadDoor : MonoBehaviour
{
  private void OnControllerColliderHit (ControllerColliderHit hit)
{
    if(hit.gameObject.tag == "PressurePad")
    {
        //Animation.Play("Door_Open")
    }
    else
    {
    //Animation.Play("Door_Colse")
    }
}
}
