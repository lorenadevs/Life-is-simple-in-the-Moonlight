using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interactuarShaman : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject interactMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    //private bool didDialogueStart;
    private int lineIndex;
    private bool isPlayerInRange;
    // Update is called once per frame
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Dialogo");
            StartDialogue();
            
        }

    }

    private IEnumerator ShowLines(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSeconds(0.05f); //Velocidad de escritura de cada caracter
        }
    }

    private void StartDialogue(){
        //didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLines[0];
        lineIndex = 0;
        StartCoroutine(ShowLines());
    }


    private void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            isPlayerInRange = true;
            interactMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            isPlayerInRange = false;
            dialoguePanel.SetActive(false);
            dialogueText.text = string.Empty;
            interactMark.SetActive(false);

        }
    }
    
}
