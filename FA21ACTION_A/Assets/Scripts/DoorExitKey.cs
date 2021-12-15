using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitKey : MonoBehaviour
{
      public string NextLevel = "MainMenu";
	  public GameHandler gameHandler;

      public void OnCollisionEnter2D(Collision2D other){
            if (other.gameObject.tag == "Player" && GameHandler.hasKey == true){
                  SceneManager.LoadScene (NextLevel);
            }
      }

}