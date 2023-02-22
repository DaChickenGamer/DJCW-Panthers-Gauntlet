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

   public void LoadNextLevel(int sceneId)    //Only has scene transition
   {
      if (transitionStop == 0)
      {
         //Method loads the scene requested the if transition has stopped
         StartCoroutine(LoadLevel(sceneId));
      }
      else
      {
         Debug.Log("transitionStop");
      }
   }

   public void loadscene(int sceneId)     //scene transition and loading screen
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

   IEnumerator LoadSceneAsync(int sceneId)      //Loading screen and level transition
   {
      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

      if (transitionStop == 0)
      {
         transition.SetTrigger("Start");

         yield return new WaitForSeconds(transitionTime);
         SceneManager.LoadScene(sceneId);
      }

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
