using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BatDamage : MonoBehaviour {

    public Animator anim;
	 //private bool isCoalAttack;
    public float speed = 4f;
    private Transform target;
    public int damage = 1;

    public int EnemyLives = 3;
    private Renderer rend;
    private GameHandler gameHandler;

    public float attackRange = 10;
    public bool isAttacking = false;

    void Start () {
		anim = GetComponentInChildren<Animator>();
        rend = GetComponentInChildren<Renderer> ();

        if (GameObject.FindGameObjectWithTag ("Player") != null) {
            target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
        }

        if (GameObject.FindWithTag ("GameHandler") != null) {
            gameHandler = GameObject.FindWithTag ("GameHandler").GetComponent<GameHandler> ();
        }
		
		anim.SetBool ("isBatAttack", false);
		anim.SetBool ("isBatControlled", false);
		//isCoalAttack = false;
    }

    void Update () {
		
				
              float DistToPlayer = Vector3.Distance(transform.position, target.position);
		  if (this.GetComponent<BatPossession>().isPossessed == false){ //isPossessed #1
              if ((target != null) && (DistToPlayer <= attackRange)){
                     transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
					 anim.SetBool("isBatAttack", true);
                     //if (isAttacking == false) {
                            //anim.SetBool("isCoalAttack", false);
                     // }
			  }
				else  {anim.SetBool("isBatAttack", false);}
               
		  }
		  else  {anim.SetBool("isBatAttack", false);}

    }



    public void OnCollisionEnter2D(Collision2D collision){  //isPossessed #2
              if ((collision.gameObject.tag == "Player")&&(this.GetComponent<BatPossession>().isPossessed == false)) {
                     isAttacking = true;
                    // anim.SetBool("isCoalAttack", true);
                     gameHandler.TakeDamage(damage);
                     rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
                     StartCoroutine(HitEnemy());
              }
    }

    public void OnCollisionExit2D(Collision2D collision){
              if (collision.gameObject.tag == "Player") {
                     isAttacking = false;
                    // anim.SetBool("isCoalAttack", false);
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