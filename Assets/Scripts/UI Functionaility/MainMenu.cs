using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public bool animationComplete = false;
   public void PlayGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void AnimationFinished()
   {
      animationComplete = true;
      Debug.Log("Animation Complete" + animationComplete);
   }
}
