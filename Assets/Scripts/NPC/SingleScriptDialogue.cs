using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleScriptDialogue : MonoBehaviour
{
    
    public List<DialogueText> dialogues;
    private int talkedTo;
    private Queue<string> sentences;

    [SerializeField] private Text NPCNameText;
    [SerializeField] private Text DialogueText;

    [SerializeField] private GameObject panel;

    void Start()
    {
        talkedTo = 0;
        sentences = new Queue<string>();
    }

    public void StartDialogue()
    {
        panel.SetActive(true);
        Debug.Log("starting convo with :" + dialogues[talkedTo].name);
        sentences.Clear();

        foreach (string sentence in dialogues[talkedTo].dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        talkedTo++;

        if (talkedTo > dialogues.Count - 1)
        {
            talkedTo = dialogues.Count - 1;
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count <= 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        NPCNameText.text = dialogues[talkedTo].name;
        DialogueText.text = sentence;
        
    }

    public void EndDialogue()
    {
        panel.SetActive(false);
        //sentences.Clear();
        Debug.Log("end");
    }
}
