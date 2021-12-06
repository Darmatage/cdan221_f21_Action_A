using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class GameHandler : MonoBehaviour {

      private GameObject player;
      public static int playerHealth;
      public int StartPlayerHealth = 100;
     public GameObject healthText;
	  public static int Lives = 4;
       public int maxLives = 4;
       public GameObject lifeHeart1;
       public GameObject lifeHeart2;
       public GameObject lifeHeart3;
       public GameObject lifeHeart4;
	     public static int MaxHealth = 100;
       public static int CurrentHealth = 100;
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
            playerHealth = StartPlayerHealth;
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
      }
     public void TakeDamage(int damage){
              CurrentHealth -= damage;
              UpdateHealth();
              sceneName = SceneManager.GetActiveScene().name;
              if (CurrentHealth >= MaxHealth){CurrentHealth = MaxHealth;}
              if ((CurrentHealth <= 0) && (sceneName != "EndLose")&& (Lives <= 0)){
                     SceneManager.LoadScene("EndLose");
               } else if (CurrentHealth <= 0){ UpdateLives(-1, "down"); }
       }
	   
	   public void UpdateLives(int lifeChange, string changeDir){
              Lives += lifeChange;
              if (changeDir == "down"){
                     if (lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(false);}  
                     else if (lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(false);}
                     else if (lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(false);}
                     else if (lifeHeart1.activeInHierarchy){lifeHeart1.SetActive(false);}
              } else if (changeDir == "up"){
                     if (!lifeHeart2.activeInHierarchy){lifeHeart2.SetActive(true);}
                     else if (!lifeHeart3.activeInHierarchy){lifeHeart3.SetActive(true);}
                     else if (!lifeHeart4.activeInHierarchy){lifeHeart4.SetActive(true);}
              }
       }

       public void UpdateHealth(){
              Text healthTextB = healthText.GetComponent<Text>();
              healthTextB.text = "Current Health: " + CurrentHealth + "\n Max Health: " + MaxHealth;
       }
      public void playerGetHit(int damage){
           if (isDefending == false){
                  playerHealth -= damage;
                  updateStatsDisplay();
                  player.GetComponent<PlayerHurt>().playerHit();
            }

           if (playerHealth >= StartPlayerHealth){
                  playerHealth = StartPlayerHealth;
            }

           if (playerHealth <= 0){
                  playerHealth = 0;
                  playerDies();
            }
      }

      public void updateStatsDisplay(){
            Text healthTextTemp = healthText.GetComponent<Text>();
            healthTextTemp.text = "HEALTH: " + playerHealth;

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "GOLD: " + gotTokens;
      }

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }

      public void StartGame() {
            SceneManager.LoadScene("Tutorial");
      }

      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
			Time.timeScale = 1f;
            playerHealth = StartPlayerHealth;
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
}