using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPossession : MonoBehaviour
{
	public Animator anim;
	//private bool isCoalControlled;
	private Renderer rend;
	public float possessRange = 10f;
	public LayerMask enemyLayer;
	
	
    // Start is called before the first frame update
    void Start()
    {
		 anim = GetComponentInChildren<Animator>();
		  rend = GetComponentInChildren<Renderer> ();
        anim.SetBool ("isCoalControlled", false);
		//isCoalControlled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
		if ((Input.GetButtonDown("Possession")) && (isEnemyInRange())) {
                  Possess();
				  anim.SetBool ("isCoalControlled", true);
				  //Debug.Log("I possess");
               //anim.SetTrigger("Controlledcoal");
               // possessSFX.Play();
            }
			else{	
			anim.SetBool ("isCoalControlled", false);	
			//anim.SetTrigger("Attackcoal");
			}
			
    }
	
	public void Possess(){
		//take 1 or more enemies in range
		//activate their "isPossessed" variable
		
        Collider2D[] posEnemies = Physics2D.OverlapCircleAll(transform.position, possessRange, enemyLayer);
        
        foreach(Collider2D enemy in posEnemies){
            Debug.Log("I possess " + enemy.name);
            enemy.GetComponent<EnemyPossession>().isPossessed=true;
        }
	}
	
	public bool isEnemyInRange(){
		Collider2D enemyCheck = Physics2D.OverlapCircle(transform.position, possessRange, enemyLayer);
		if (enemyCheck != null) {
                  return true;
                  Debug.Log("An enemy is in range for possession!");
            }
		else {Debug.Log("No enemy in range to possess"); return false;}
            return false;
	}
	
	
	//DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, possessRange);
       }
	
}
