using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    public GameObject volumeMenu, videoMenu, returnToGymButton;
    private bool paused, volumeFade, videoFade, volumeActive, volumeFadeOut, videoActive, videoFadeOut;
    private float timeManagement;
    private void Awake()
    {
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        timeManagement = Time.deltaTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym"))
        {
            returnToGymButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (volumeActive)
        {
            Volume();
        }
        if (videoActive)
        {
            Video();
        }
        if (KeybindManager.MyInstance.Actions.FindAction("Pause").IsInProgress())
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (!paused)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            paused = true;
        }
        else if (paused)
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            paused = false;
        }
    }
    public void Volume()
    {
        volumeActive = true;
        if(volumeMenu.GetComponent<CanvasGroup>().alpha < 1&&!volumeFadeOut)
        {
            volumeMenu.SetActive(true);
            videoMenu.GetComponent<CanvasGroup>().alpha -= timeManagement;
            volumeMenu.GetComponent<CanvasGroup>().alpha += timeManagement;
            if(volumeMenu.GetComponent<CanvasGroup>().alpha >= 1)
            {
                videoFade = false;
                videoFadeOut = false;
                videoMenu.GetComponent<CanvasGroup>().alpha = 0;
                videoActive = false;
                videoMenu.SetActive(false);
                volumeMenu.GetComponent<CanvasGroup>().alpha = 1;
                volumeFade = true;
                volumeActive = false;
                
            }
        }
        if(volumeFade)
        {
            volumeFadeOut = true;
            if (volumeMenu.GetComponent<CanvasGroup>().alpha <= 1)
            {
                volumeMenu.GetComponent<CanvasGroup>().alpha -= timeManagement;
                if(volumeMenu.GetComponent<CanvasGroup>().alpha <= 0)
                {
                    volumeFade = false;
                    volumeFadeOut = false;
                    volumeMenu.GetComponent<CanvasGroup>().alpha = 0;
                    volumeActive=false;
                    volumeMenu.SetActive(false);
                }
            }
        }
    }
    public void Video()
    {
        videoActive = true;
        if (videoMenu.GetComponent<CanvasGroup>().alpha < 1 && !videoFadeOut)
        {

            videoMenu.SetActive(true);
            volumeMenu.GetComponent<CanvasGroup>().alpha-= timeManagement;
            videoMenu.GetComponent<CanvasGroup>().alpha += timeManagement;
            if (videoMenu.GetComponent<CanvasGroup>().alpha >= 1)
            {
                volumeFade = false;
                volumeFadeOut = false;
                volumeMenu.GetComponent<CanvasGroup>().alpha = 0;
                volumeActive = false;
                volumeMenu.SetActive(false);
                videoMenu.GetComponent<CanvasGroup>().alpha = 1;
                videoFade = true;
                videoActive = false;
                
            }
        }
        if (videoFade)
        {
            videoFadeOut = true;
            if (videoMenu.GetComponent<CanvasGroup>().alpha <= 1)
            {
                videoMenu.GetComponent<CanvasGroup>().alpha -= timeManagement;
                if (videoMenu.GetComponent<CanvasGroup>().alpha <= 0)
                {
                    videoFade = false;
                    videoFadeOut = false;
                    videoMenu.GetComponent<CanvasGroup>().alpha = 0;
                    videoActive = false;
                    videoMenu.SetActive(false);
                }
            }
        }
    }
    public void Back()
    {
        videoFade = false;
        videoFadeOut = false;
        videoMenu.GetComponent<CanvasGroup>().alpha = 0;
        videoActive = false;
        videoMenu.SetActive(false);
        volumeFade = false;
        volumeFadeOut = false;
        volumeMenu.GetComponent<CanvasGroup>().alpha = 0;
        volumeActive = false;
        volumeMenu.SetActive(false);
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        paused = false;
    }
}
