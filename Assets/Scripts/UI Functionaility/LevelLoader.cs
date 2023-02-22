using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
   public GameObject LoadingScreen;
   public Image LoadingBarFill;
   public Animator transition;

   private static float transitionStop = 0f;

   public float transitionTime = 1f;
    // Update is called once per frame

   public void LoadNextLevel()
   {
      if (transitionStop == 0)
      {
         //Method that checks for the next scene that is loaded
         StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
      }
      else
      {
         Debug.Log("transitionStop");
      }
   }

   public void loadscene(int sceneId)
   {
        StartCoroutine(LoadSceneAsync(sceneId));
   }


   IEnumerator LoadLevel(int sceneId)     //Level transition
   {
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);
      
      if (transitionStop == 0)
      {
         transition.SetTrigger("Start");

         yield return new WaitForSeconds(transitionTime);
         SceneManager.LoadScene(sceneId);
      }
   }

   IEnumerator LoadSceneAsync(int sceneId)      //Loading screen
   {
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

      LoadingScreen.SetActive(true);
      while(!operation.isDone)
      {
         float progressValue = Mathf.Clamp01(operation.progress / 0.9f);        

         LoadingBarFill.fillAmount = progressValue;

         yield return null;
      }
   }

   public void QuitGame()     //Quit game
   {
      Application.Quit();
   }


   
}
