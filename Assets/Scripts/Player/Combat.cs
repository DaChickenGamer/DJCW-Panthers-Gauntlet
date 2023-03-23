using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combat : EnemyValues
{
    public static Animator animator;
    public Slider slider;

    [Header("Attack Hitboxes")]
    public GameObject Kick_Down;
    public GameObject Kick_Left, Kick_Right, Kick_Up, Punch_Down, Punch_Left, Punch_Right, Punch_Up;

    [Header("Grapple Meter")]
    public GameObject GrappleMeter;
    private float grappledelay; // The delay after grapple so you can't spam the button

    [HideInInspector][Header("Attack Values")]
    private float kickValue; // Used for the input system
    private float punchValue; // Also used for the input system

    private float attackSpawnDelay = 0.25f; // Waits to spawn another attack for the player
    private bool isAttacking; // Checks if the player is attacking

    [Header("Grapple Bools")]
    [SerializeField] private int grappleWinCounter = 0;
    [SerializeField] private bool inGrappleState = false;
    [HideInInspector] public bool grappled;

    [Header("Grapple Settings")]
    // Higher for harder characters
    [SerializeField] private float attackDelay; // Delays players attack

    [Header("Enemy")]
    public Collider2D enemycollider;
    public Collider2D playercollider;

    private bool inputDelay = false;
    private void Start()
    {
        slider.value = (winCount + failCount) / 2;
        slider.maxValue = winCount; // Grappling Highest Amount
        slider.minValue = failCount; // Grappling Lowest Amount
    }
    private void Awake()
    {
       animator = GetComponent<Animator>();
    }
    private void OnPunch(InputValue value)
    {
        if (!animator.GetBool("isKnocked")&&!animator.GetBool("isGrapple"))
        {
            punchValue = value.Get<float>();

            if (punchValue != 0)
            {
                animator.SetBool("isPunching", true);
                isAttacking = false;
            }
            else
            {
                animator.SetBool("isPunching", false);
                isAttacking = true;
            }
            Debug.Log("Punched");
        }
    }
    private void OnKick(InputValue value)
    {
        if (!animator.GetBool("isKnocked")&&!animator.GetBool("isGrapple"))
        {
            kickValue = value.Get<float>();

            if (kickValue != 0)
            {
                animator.SetBool("isKicking", true);
                isAttacking = false;
            }
            else
            {
                animator.SetBool("isKicking", false);
                isAttacking = true;
            }
            Debug.Log("Kicked");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        enemycollider=collision;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        enemycollider= playercollider;
    }
    private void OnGrapple(InputValue value)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Gym") && enemycollider.gameObject.tag == "Enemy" && grappledelay <= 0 && !animator.GetBool("isKnocked"))
        {
                if (inGrappleState == false)
                {
                    grappleWinCounter = 0;
                    inGrappleState = true;
                    animator.SetBool("isGrapple", true);
                }
                else if (inGrappleState == true)
                {
                    Debug.Log("Grapple " + grappleWinCounter);
                    grappleWinCounter++;

                }
            }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Gym"))
        {
            slider.gameObject.SetActive(true);
            slider.value = grappleWinCounter;
            if (PlayerHealth.currentHealth <= 0)
            {
                animator.SetBool("isKnocked", true);
            }
            if (!animator.GetBool("isKnocked"))
            {
                if (grappledelay > 0)
                {
                    grappledelay -= Time.deltaTime;
                }

                if (attackDelay > 0)
                    attackDelay -= Time.deltaTime;
                if (inGrappleState == true)
                {
                    if (grappleWinCounter >= winCount)     //detects player's success in grapple
                    {
                        Debug.Log("You won the grapple");
                        grappleWinCounter = 0;
                        inGrappleState = false;
                        animator.SetBool("isGrapple", false);
                    }

                    if (grappleWinCounter <= failCount)    //detects player's falure in grapple
                    {
                        Debug.Log("You lossed the grapple");
                        grappleWinCounter = 0;
                        inGrappleState = false;
                        animator.SetBool("isGrapple", false);
                    }

                    if (inputDelay == false) //delays bot input
                    {
                        StartCoroutine(BotDelay());
                        inputDelay = true;
                    }
                }
            }
        }
        else if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gym"))
        {
            slider.gameObject.SetActive(false);
        }
            IEnumerator BotDelay()      //delays value addition
            {
                yield return new WaitForSeconds(delay);

                grappleWinCounter--;
                Debug.Log("Grapple " + grappleWinCounter);
                inputDelay = false;
            }
            if (animator.GetBool("isGrapple"))
            {
                if (!grappled)
                {
                    slider.gameObject.SetActive(true);
                    grappled = true;
                    animator.SetBool("isWalking", false);
                }
            }
            if (!animator.GetBool("isGrapple"))
            {
                if(grappled) grappledelay = 2f;
                grappled = false;
                slider.gameObject.SetActive(false);
            }
            SpawnAttacks();
    }
    void SpawnAttacks()
    {
        if (attackDelay <= 0 && isAttacking)
        {
            if (animator.GetBool("isPunching"))
            {
                if (animator.GetFloat("X") > 0)
                {
                    Instantiate(Punch_Right, this.transform); attackDelay = attackSpawnDelay;
                }
                if (animator.GetFloat("X") < 0)
                {
                    Instantiate(Punch_Left, this.transform); attackDelay = attackSpawnDelay;
                }
                if (animator.GetFloat("Y") > 0)
                {
                    Instantiate(Punch_Up, this.transform); attackDelay = attackSpawnDelay;
                }
                if (animator.GetFloat("Y") < 0)
                {
                    Instantiate(Punch_Down, this.transform); attackDelay = attackSpawnDelay;
                }
            }
            if (animator.GetBool("isKicking"))
            {
                if (animator.GetFloat("X") > 0)
                {
                    Instantiate(Kick_Right, this.transform); attackDelay = attackSpawnDelay;
                }
                if (animator.GetFloat("X") < 0)
                {
                    Instantiate(Kick_Left, this.transform); attackDelay = attackSpawnDelay;
                }
                if (animator.GetFloat("Y") > 0)
                {
                    Instantiate(Kick_Up, this.transform); attackDelay = attackSpawnDelay;
                }
                if (animator.GetFloat("Y") < 0)
                {
                    Instantiate(Kick_Down, this.transform); attackdelay = attackSpawnDelay;
                }
            }
        }
    }
}
