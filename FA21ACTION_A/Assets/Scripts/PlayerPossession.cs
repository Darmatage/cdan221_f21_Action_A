using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossession : MonoBehaviour
{
	
	public float possessRange = 10f;
	public LayerMask enemyLayer;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
		if ((Input.GetButtonDown("Possession")) && (isEnemyInRange())) {
                  Possess();
               // anim.SetTrigger("Possess");
               // possessSFX.Play();
            }
			else {Debug.Log("No enemy in range to possess");}
    }
	
	public void Possess(){
		//take 1 or more enemies in range
		//activate their "isPossessed" variable
		Collider2D enemies = Physics2D.OverlapCircle(transform.position, possessRange, enemyLayer);
		enemies.GetComponent<EnemyMoveHit>().isPossessed = true;
		
		//for(int i = 0; i<enemies.Length; i++){
		//	enemies[i].GetComponent<EnemyMoveHit>().isPossessed = true;
		//}
	}
	
	public bool isEnemyInRange(){
		Collider2D enemyCheck = Physics2D.OverlapCircle(transform.position, possessRange, enemyLayer);
		if (enemyCheck != null) {
                  return true;
                  Debug.Log("An enemy is in range for possession!");
            }
            return false;
	}
	
	
	//DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, possessRange);
       }
	
}
