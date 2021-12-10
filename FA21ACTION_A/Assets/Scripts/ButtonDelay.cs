using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonDelay : MonoBehaviour
{
	
	 public string sceneToChangeTo = "Tutorial";
	 
    // Start is called before the first frame update
     public void ChangeToScene()
		{
		StartCoroutine(DoChangeScene(sceneToChangeTo,1f));
		}
			
		public IEnumerator DoChangeScene(string sceneToChangeTo,float delay)
		{
				yield return new WaitForSeconds(delay);
				SceneManager.LoadScene(sceneToChangeTo);
		}

}

