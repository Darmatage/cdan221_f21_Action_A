using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

       private float speed = 2f;
       private bool moveToA = true;
       public Transform moveTargetA;
       public Transform moveTargetB;
       private Vector2 mTA;
       private Vector2 mTB;

       void FixedUpdate(){
              mTA = new Vector2(moveTargetA.position.x, moveTargetA.position.y);
              mTB = new Vector2(moveTargetB.position.x, moveTargetB.position.y);
              float step = speed * Time.deltaTime;        // calculate distance to move

              if (moveToA){
                     transform.position = Vector2.MoveTowards(transform.position, mTA, step);
              } else {
                     transform.position = Vector2.MoveTowards(transform.position, mTB, step);
              }

              if (Vector2.Distance(moveTargetA.position, transform.position) < 1){moveToA = false;}
              else if (Vector2.Distance(moveTargetB.position, transform.position) < 1){moveToA = true;}
       }

       void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.tag == "Player"){
                     other.collider.transform.SetParent(transform);        // so Player moves with platform
              }
       }

       void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.tag == "Player"){
                     other.collider.transform.SetParent(null);        // Player not parented when off platform
              }
       }

}