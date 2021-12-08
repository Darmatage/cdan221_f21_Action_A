using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerBottomRespawn : MonoBehaviour {

       public GameHandler gameHandler;
       public Transform playerPos;
       public Transform pSpawn;
       public int damage = 1;

       void Start() {
              playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
              gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
       }

       void Update() {
              if (playerPos != null){
                     if (transform.position.y >= playerPos.position.y){
                            //instantiate a particle effect
                            Debug.Log("I am going back to the start");
                            gameHandler.TakeDamage(damage);
                            Vector2 pSpn2 = new Vector2(pSpawn.position.x, pSpawn.position.y);
                            playerPos.position = pSpn2;
                     }
              }
       }
}