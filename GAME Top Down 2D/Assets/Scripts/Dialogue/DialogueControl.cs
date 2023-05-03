using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; // janela chat
    public Image profileSprite; // sprite do perfil
    public Text speechText; // texto do chat
    public Text actorNameText; // nome npc

    [Header("Settings")]
    public float typingSpeed; // velocidade do chat

    //Variáveis de controle
    [HideInInspector] public bool isShowing; // se a janela está visível
    private int index; // qtd de texto que tem no chat
    private string[] sentences;

    public static DialogueControl instance;

    //awake é chamado antes de todos os Start() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {

        foreach (char letter in sentences[index].ToCharArray())
        {

            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

    }

    public void NextSentence() //pular para próxima frase/fala
    {

        if(speechText.text == sentences[index])
        {

            if(index < sentences.Length - 1)
            {

                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());

            }
            else // quando termina os textos
            {

                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;

            }

        }

    }

    public void Speech(string[] txt) //chamar a fala do npc
    {

        if (!isShowing)
        {

            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;

        }

    }
}
