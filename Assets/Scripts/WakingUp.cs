using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WakingUp : MonoBehaviour
{
    /*Animator animator;
    string currentState;

    const string Down = "";
    const string GettingUp = "";
    public Text timeOut;
    public GameObject Awake, text; //Select the "projectile" object to spawn
    public Transform spawnLocation; //Location to spawn "projectile"
    public Quaternion spawnRotation;
    float wait = 1,waiting,finished;
    bool revive = false;
    bool win=false;
    // Start is called before the first frame update
    void Start()
    {
        finished = 0;
        ChangeAnimationState(Down);
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting == 0)
        {
            //waiting = wait + 2 * (EnemyHealth.knocked);
        }
        else if (waiting > 0)
        {
            if (waiting == 5)
            {
                win = true;
            }
            waiting -= Time.deltaTime;
            Debug.Log("time");
        }
        else if (waiting <= 0)
        {
            
            revive = true;
        }
        if (waiting <= 1)
            ChangeAnimationState(GettingUp);
        if (win&&waiting<=0)
        {
            SceneManager.LoadScene(0);
        }
        if (revive)
        {
            Instantiate(Awake, spawnLocation.position, spawnRotation);
            Destroy(text);
            Destroy(gameObject);
        }
        if (finished <= 6)
        {
            finished +=Time.deltaTime;
        }
        if(finished<1)
            timeOut.text = "1";
        else if (finished<2)
            timeOut.text = "2";
        else if (finished<3)
            timeOut.text = "3";
        else if (finished<4)
            timeOut.text = "4";
        else if (finished<5)
            timeOut.text = "5";
        
    }
    void ChangeAnimationState(string newState)
    {
        //Stop animation from interrupting itself
        if (currentState == newState) return;

        // Plays new animation
        animator.Play(newState);



        //Update current state
        currentState = newState;
    }*/
    
}
