using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpickup : MonoBehaviour
{

      //public playerVFX playerPowerupVFX;
     
      //public bool isSpeedBoostPickUp = false;
	   public AudioSource heartSFX;


     
      //public float speedBoost = 2f;
      //public float speedTime = 2f;

      void Start(){
            
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
		
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  //GetComponent<AudioSource>().Play();
				  // StartCoroutine(HideThis());
                  StartCoroutine(DestroyThis());
				   heartSFX.Play();
				

                  //if (isSpeedBoostPickUp == true) {
                  //      other.gameObject.GetComponent<PlayerMove>().speedBoost(speedBoost, speedTime);
                        //playerPowerupVFX.powerup();
                  //}
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
      }
		// IEnumerator HideThis(){
            // yield return new WaitForSeconds(0.2f);
            // GameObject.Find ("Circle").transform.localScale = new Vector3(0, 0, 0);
      // }
}