using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameHandler : MonoBehaviour {

      private GameObject player;
      //public static int playerHealth;
      //public int StartPlayerHealth = 8;
     public GameObject healthText;
	  public static int Lives = 8;
       public int maxLives = 8;
       public GameObject lifeHeart1;
       public GameObject lifeHeart2;
       public GameObject lifeHeart3;
       public GameObject lifeHeart4;
	    public GameObject lifeHeart5;
       public GameObject lifeHeart6;
       public GameObject lifeHeart7;
       public GameObject lifeHeart8;
	  public static bool hasWand = false;
	  public static bool npcTalking = false;
	  public static bool hasKey = false;
	   public static bool CoalInRange = false;
	  public static bool BatInRange = false;
	  

	    // public static int MaxHealth = 8;
       //public static int CurrentHealth = 8;
       private string sceneName;


    public static int gotTokens = 0;
    public GameObject tokensText;
	 public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public AudioMixer mixer;
        public static float volumeLevel = 1.0f;
        private Slider sliderVolumeCtrl;

      public bool isDefending = false;

      public static bool stairCaseUnlocked = false;
	  
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;
  void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
        }
      void Start(){
		    pauseMenuUI.SetActive(false);
            player = GameObject.FindWithTag("Player");
	//playerHealth = StartPlayerHealth;
            updateStatsDisplay();       
      }
 void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
				
        }

        void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }
		
		  public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void SetLevel (float sliderValue){
                mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                volumeLevel = sliderValue;
        }
		
       public void playerGetTokens(int newTokens){
            gotTokens += newTokens;
             updateStatsDisplay();
			 if (gotTokens >= 99){
				 gotTokens = 0;
				 UpdateLives(1,"up");
				 
			 }
       }
     public void TakeDamage(int damage){
              Lives -= damage;
              UpdateLives(-1,"down");
			  
	 if(Lives >= 1){
		player.GetComponent<PlayerRespawn>().RespawnChar();
	 }
			  
              sceneName = SceneManager.GetActiveScene().name;
              if (Lives >= maxLives){Lives = maxLives;}
              if ((Lives <= 0) && (sceneName != "End_Lose")){
                     SceneManager.LoadScene("End_Lose");
               } 
			   //else if (CurrentHealth <= 0){ UpdateLives(-1, "down"); }
       }
	   
	   public void UpdateLives(int lifeChange, string changeDir){
              Lives += lifeChange;
              if (changeDir == "down"){
                     if (lifeHeart8.activeInHierarchy){lifeHeart8.SetActive(false);} 
						else if (lifeHeart7.activeInHierarchy){lifeHeart7.SetActive(false);}
						else if (lifeHeart6.activeInHierarchy){lifeHeart6.SetActive(false);}
						else if (lifeHeart5.activeInHierarchy){lifeHeart5.SetActive(false);}
						else if (lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(false);}					 
                     else if (lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(false);}
                     else if (lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(false);}
                     else if (lifeHeart1.activeInHierarchy){lifeHeart1.SetActive(false);}
              } else if (changeDir == "up"){
                     if (!lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(true);}
                     else if (!lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(true);}
                     else if (!lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(true);}
					 else if (!lifeHeart5.activeInHierarchy){lifeHeart5.SetActive(true);}
					 else if (!lifeHeart6.activeInHierarchy){lifeHeart6.SetActive(true);}
					 else if (!lifeHeart7.activeInHierarchy){lifeHeart7.SetActive(true);}
					 else if (!lifeHeart8.activeInHierarchy){lifeHeart8.SetActive(true);}
              }
       }

       // public void UpdateHealth(){
              // Text healthTextB = healthText.GetComponent<Text>();
              // healthTextB.text = "Current Health: " + CurrentHealth + "\n Max Health: " + MaxHealth;
       // }
      // public void playerGetHit(int damage){
           // if (isDefending == false){
                  // Lives -= damage;
                  // updateStatsDisplay();
                  // player.GetComponent<PlayerHurt>().playerHit();
            // }

           // if (playerHealth >= StartPlayerHealth){
                  // playerHealth = StartPlayerHealth;
            // }

           // if (playerHealth <= 0){
                  // playerHealth = 0;
                  // playerDies();
            // }
      // }

       public void updateStatsDisplay(){
           // Text healthTextTemp = healthText.GetComponent<Text>();
           // healthTextTemp.text = "HEALTH: " + playerHealth;

             Text tokensTextTemp = tokensText.GetComponent<Text>();
             tokensTextTemp.text = "SHIMMERS:" + gotTokens;
       }

	
      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("End_Lose");
      }

      public void StartGame() {
       StartCoroutine(myDelay2());     
      }

	public void LevelOne() {
            SceneManager.LoadScene("Tutorial");
      }
	  
		public void LevelTwo() {
            SceneManager.LoadScene("Village_backup");
      }
	  
	  public void LevelThree() {
            SceneManager.LoadScene("CAVE_LEVEL");
      }
	  
	    public void LevelFour() {
            SceneManager.LoadScene("Volcano_Level");
      }
	  
	   public void GotoLevelSelect() {
            SceneManager.LoadScene("LevelSelect");
      }
	  
      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
			Time.timeScale = 1f;
            Lives = maxLives;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }
	  
	  	IEnumerator myDelay2(){
     yield return new WaitForSeconds(2f); //will delay about two seconds. Set this number as desired
	  Debug.Log("2 second past");
     SceneManager.LoadScene("Tutorial");
}
}