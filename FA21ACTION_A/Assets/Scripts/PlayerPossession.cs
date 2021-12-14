using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossession : MonoBehaviour{
	public Animator anim;
	private Renderer rend;
	public float possessRange = 10f;
	public LayerMask enemyLayer;
	public AudioSource possessSFX;
	public GameHandler gameHandlerObj;
	
    // Start is called before the first frame update
    void Start(){
		anim = GetComponentInChildren<Animator>();
		rend = GetComponentInChildren<Renderer> ();
		gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      
    }

    // Update is called once per frame
    void Update(){
		if ((Input.GetButtonDown("Possession")) && (isEnemyInRange()) && (GameHandler.hasWand == true)){
            Possess();
			anim.SetTrigger("PlayerDoesControl");
			
			//Debug.Log("I possess");
            possessSFX.Play();
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
            Debug.Log("An enemy is in range for possession!");
			return true;
		}
		else {
			Debug.Log("No enemy in range to possess"); 
			return false;
		}
	}
	
	
	//DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, possessRange);
       }
	
}
