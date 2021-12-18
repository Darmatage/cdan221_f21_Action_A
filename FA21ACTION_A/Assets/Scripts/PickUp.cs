using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      public GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool isHealthPickUp = true;
      //public bool isSpeedBoostPickUp = false;
	   public AudioSource heartSFX;


      public int healthBoost = 1;
      //public float speedBoost = 2f;
      //public float speedTime = 2f;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
		
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  //GetComponent<AudioSource>().Play();
				  // StartCoroutine(HideThis());
                  StartCoroutine(DestroyThis());
				   heartSFX.Play();
				isHealthPickUp = true;
				 if (isHealthPickUp == true) {
                        gameHandler.UpdateLives(healthBoost,"up");
                        heartSFX.Play();
                  }


                  //if (isSpeedBoostPickUp == true) {
                  //      other.gameObject.GetComponent<PlayerMove>().speedBoost(speedBoost, speedTime);
                        //playerPowerupVFX.powerup();
                  //}
            }
      }

      IEnumerator DestroyThis(){
		                   
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }
		// IEnumerator HideThis(){
            // yield return new WaitForSeconds(0.2f);
            // GameObject.Find ("Circle").transform.localScale = new Vector3(0, 0, 0);
      // }
}