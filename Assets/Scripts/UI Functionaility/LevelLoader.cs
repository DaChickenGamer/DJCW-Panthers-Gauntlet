using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
   
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

   IEnumerator LoadLevel(int levelIndex)
   {
      if (transitionStop == 0)
      {
         transition.SetTrigger("Start");

         yield return new WaitForSeconds(transitionTime);
         SceneManager.LoadScene(levelIndex);
      }
   }

   public void QuitGame()
   {
      Application.Quit();
   }

   public void NextScene()
   {
      
   }
}
