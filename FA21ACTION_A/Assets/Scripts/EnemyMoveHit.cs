using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveHit : MonoBehaviour {

      //public Animator anim;
       public float speed = 4f;
       private Transform target;
       public int damage = 5;

       public int EnemyLives = 3;
       private Renderer rend;
       private GameHandler gameHandler;

       public float attackRange = 10;
       public bool isAttacking = false;

//posession variables
		public bool isPossessed = false;
		public Rigidbody2D rb2D;
		private Vector3 hMove;
		private bool FaceRight = true; // determine which way player is facing.
		public static float runSpeed = 10f;
		public float jumpForce = 5f;

       public int possessionTimer = 5;
       private float theTimer = 0f;
       //public GameObject timerText;


       void Start () {
              rend = GetComponentInChildren<Renderer> ();
			  rb2D = transform.GetComponent<Rigidbody2D>();

              if (GameObject.FindGameObjectWithTag ("Player") != null) {
                     target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
              }

            if (GameObject.FindWithTag ("GameHandler") != null) {
                gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
              }
       }

       void Update () {
              float DistToPlayer = Vector3.Distance(transform.position, target.position);

		  if (isPossessed == false){
              if ((target != null) && (DistToPlayer <= attackRange)){
                     transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
                     if (isAttacking == false) {
                            //anim.SetBool("Walk", true);
                     }
                     //else  { anim.SetBool("Walk", false);}
              } 
               //else { anim.SetBool("Walk", false);}
		  }
		  else {
			  //possessed actions
			  Debug.Log("I am possessed!");
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
		  }
       }

//possessed functions
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
			  }
		   }
      }

      public void UpdateTimer(){
            //Text timeTextTemp = timerText.GetComponent<Text>();
            //timeTextTemp.text = "" + possessionTimer;
			rend.material.color = new Color(0.9f, 2.4f, 0.9f, 1f);
			StartCoroutine(HitEnemy());
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
            rb2D.velocity = Vector2.up * jumpForce;
      }
	  
//regular enemy attack functions

       public void OnCollisionEnter2D(Collision2D collision){
              if ((collision.gameObject.tag == "Player")&&(isPossessed == false)) {
                     isAttacking = true;
                     //anim.SetBool("Attack", true);
                     gameHandler.playerGetHit(damage);
                     rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     StartCoroutine(HitEnemy());
              }
       }

       public void OnCollisionExit2D(Collision2D collision){
              if (collision.gameObject.tag == "Player") {
                     isAttacking = false;
                     //anim.SetBool("Attack", false);
              }
       }

       IEnumerator HitEnemy(){
              yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
       }

       //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}
