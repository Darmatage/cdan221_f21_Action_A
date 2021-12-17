using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrowDamage : MonoBehaviour
{
       public Animator anim;
       public GameObject healthLoot;
       public int maxHealth = 100;
       public int currentHealth;
	   public AudioSource EnemyHitSFX;
	   public AudioSource EnemyDieSFX;

       void Start(){
		    anim = gameObject.GetComponentInChildren<Animator>();
              currentHealth = maxHealth;
       }

       public void TakeDamage(int damage = 20){
              currentHealth -= damage;
			  EnemyHitSFX.Play();
              anim.SetTrigger ("ishit");
              if (currentHealth <= 0){
                     Die();
					 EnemyDieSFX.Play();
              }
       }

       void Die(){
              Instantiate (healthLoot, transform.position, Quaternion.identity);
              //anim.SetBool ("isDead", true);
              GetComponent<Collider2D>().enabled = false;
              this.enabled = false;
              StartCoroutine(Death());
       }

       IEnumerator Death(){
              yield return new WaitForSeconds(0.5f);
              Debug.Log("You Killed a baddie. You deserve loot!");
              Destroy(gameObject);
       }
	   
	   

}