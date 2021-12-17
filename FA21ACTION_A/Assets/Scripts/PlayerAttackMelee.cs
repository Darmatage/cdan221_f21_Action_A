using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour{

      public Animator anim;
      public Transform attackPt;
      public float attackRange = 1f;
      public float attackRate = 2f;
      private float nextAttackTime = 0f;
      public int attackDamage = 40;
      public LayerMask enemyLayers;
	  public GameHandler gameHandler;

      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
		   gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      }

      void Update(){
           if (Time.time >= nextAttackTime && GameHandler.npcTalking == false){
                  //if (Input.GetKeyDown(KeyCode.Space))
                 if (Input.GetAxis("Attack") > 0){
                        Attack();
                        nextAttackTime = Time.time + 1f / attackRate;
                  }
            }
      }

      void Attack(){
            anim.SetTrigger("PlayerDoesAttack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPt.position, attackRange, enemyLayers);
           
            foreach(Collider2D enemy in hitEnemies){
                  Debug.Log("We hit " + enemy.name);
                  enemy.GetComponent<EnemyMeleeDamage>().TakeDamage(attackDamage);
            }
      }

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (attackPt == null) {return;}
            Gizmos.DrawWireSphere(attackPt.position, attackRange);
      }
}