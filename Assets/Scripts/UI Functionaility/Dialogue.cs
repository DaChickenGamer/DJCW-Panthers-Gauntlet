using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;

    private bool doDialogue = false;
    private int index;

    private void OnDialogue(InputValue value)
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
    private void Start()
    {
        textComponent.gameObject.SetActive(false);
        dialogueBox.gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Key Pressed");
            doDialogue = true;
            StartDialogue();
        }    
    }
    void StartDialogue()
    {
        if (doDialogue == true)
        {
            textComponent.gameObject.SetActive(true);
            dialogueBox.gameObject.SetActive(true);
            index = 0;
            StartCoroutine(TypeLine());
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator TypeLine()
    {
        // Type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
