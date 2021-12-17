
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Dialogue : MonoBehaviour {
       //private Animator anim;
       private NPCDialogueManager dialogueMNGR;
       public string[] dialogue; //enter dialogue lines into the inspector for each NPC
       public bool playerInRange = false; //could be used to display an image: hit [e] to talk
       public int dialogueLength;
	   
	   public GameObject pressSpaceMSG;

       void Start(){
              //anim = gameObject.GetComponentInChildren<Animator>();
			   pressSpaceMSG.SetActive(false);
              dialogueLength = dialogue.Length;
              if (GameObject.FindWithTag("DialogueManager")!= null){
                     dialogueMNGR = GameObject.FindWithTag("DialogueManager").GetComponent<NPCDialogueManager>();
              }
			
       }
	void Update () {
            if ((Input.GetKeyDown(KeyCode.LeftShift)) && (playerInRange)){ //can change the key to
                     dialogueMNGR.LoadDialogueArray(dialogue, dialogueLength);
                     dialogueMNGR.OpenDialogue();
					 pressSpaceMSG.SetActive(false); 
            }
	}
	    
       private void OnTriggerStay2D(Collider2D other){
              if (other.gameObject.tag == "Player") {
                     playerInRange = true;
					 pressSpaceMSG.SetActive(true);
              }
       }

       private void OnTriggerExit2D(Collider2D other){
              if (other.gameObject.tag =="Player") {
                     playerInRange = false;
					 dialogueMNGR.CloseDialogue();
					 pressSpaceMSG.SetActive(false);
                     //anim.SetBool("Chat", false);
                     //Debug.Log("Player left range");
              }
       }
}

   