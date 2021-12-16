using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPossession : MonoBehaviour
{
   public bool isPossessed = false;
	public Animator anim;
	public int possessionTimer = 5;
	private int possessionTimerStart;
    private float theTimer = 0f;
    //public GameObject timerText;
	
	public Rigidbody2D rb2D;
	private Vector3 hMove;
	private bool FaceRight = true; // determine which way player is facing.
	public static float runSpeed = 10f;
	public float jumpForce = 5f;
	
	private Renderer rend;

    void Start(){
		 anim = GetComponentInChildren<Animator>();
		possessionTimerStart = possessionTimer;
		//rb2D = transform.GetComponent<Rigidbody2D>();
        rend = GetComponentInChildren<Renderer>();
    }
	
	void Update (){
		//possessed actions
		if (isPossessed==true) {
			anim.SetBool ("isBatControlled", true);
			//Debug.Log("I am possessed!");
			hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
			transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
			if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
                playerTurn();
			}
			
			if (Input.GetButtonDown("Jump")) {
                Jump();
                // animator.SetTrigger("Jump");
                // JumpSFX.Play();
            }
		}else {anim.SetBool ("isBatControlled", false);}
	}

    void FixedUpdate(){
		if(isPossessed == true){
            theTimer += 0.01f;
            if (theTimer >= 1f){
                possessionTimer -=1;
                theTimer = 0;
				Debug.Log("Possession ends in " + possessionTimer + " seconds.");
                UpdateTimer();
              }
			if (possessionTimer <=0){
				isPossessed = false;
				possessionTimer = possessionTimerStart;
				
			}
		}
    }

    public void UpdateTimer(){
        //Text timeTextTemp = timerText.GetComponent<Text>();
        //timeTextTemp.text = "" + possessionTimer;
		rend.material.color = new Color(0.9f, 2.4f, 0.9f, 1f);
		StartCoroutine(clearColor());
    }

    IEnumerator clearColor(){
        yield return new WaitForSeconds(0.5f);
        rend.material.color = Color.white;
    }


	private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
	}

     public void Jump() {
            // rb2D.velocity = Vector2.up * jumpForce;
     }


	public void TurnOnPossessed(){isPossessed = true;}
	public void TurnOffPossessed(){isPossessed = false;}
	public bool AmIPossessed(){
		if (isPossessed==true){return true;}
		else if (isPossessed==false){return false;}		
		return false;
	}


}