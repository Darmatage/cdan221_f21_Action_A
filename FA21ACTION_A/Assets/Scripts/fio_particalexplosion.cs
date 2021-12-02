using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fio_particalexplosion : MonoBehaviour
{

	 public GameObject hitParticles;
     public Vector3 spwnPoint;
	
	
    // Start is called before the first frame update
    void Start()
    {
		spwnPoint = this.gameObject.transform.position;
        
    }

	void Update(){
		if (Input.GetKeyDown(KeyCode.P)){
			boom();
		}
    }

    // Update is called once per frame
    public void boom()
    {
        
		GameObject particleSys = Instantiate (hitParticles, spwnPoint, transform.rotation);
        StartCoroutine(destroyParticles(particleSys));
		
    }
	
	IEnumerator destroyParticles(GameObject pSys){
              yield return new WaitForSeconds(5f);
              Destroy(pSys);
    }

}

