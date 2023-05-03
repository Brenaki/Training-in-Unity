using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRage; // Colisor
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();

    void Start()
    {

        GetNPCInfo();

    }

    // é chamado a cada frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && playerHit)
        {

            DialogueControl.instance.Speech(sentences.ToArray());

        } 

    }

    // Pega os dialogos
    void GetNPCInfo()
    {
        // vai rodar qdt de vezes necessário para terminar a falar com o NPC
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {

            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentences.portuguese);
                    break;
                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentences.english);
                    break;
                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentences.spanish);
                    break;
            }

        }

    }

    // é usado pela física
    void FixedUpdate()
    {

        ShowDialogue();

    }

    void ShowDialogue()
    {

        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRage, playerLayer);
        
        if(hit != null)
        {

            playerHit = true;

        }
        else
        {

            playerHit = false;

        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(transform.position, dialogueRage);

    }

}
