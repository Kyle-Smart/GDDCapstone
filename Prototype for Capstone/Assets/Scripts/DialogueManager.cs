using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> theDialog;
    [SerializeField]
    Text narratorText;
    // Start is called before the first frame update
    void Start()
    {
        theDialog = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        theDialog.Clear();
        narratorText.text = "";

        foreach (string sentence in dialogue.sentences)
        {
            theDialog.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (theDialog.Count == 0)
        {
            EndDialogue();
            return;
        }

        string nextSentence = theDialog.Dequeue();

        narratorText.text = nextSentence;
    }

    public void EndDialogue()
    {
        narratorText.text = "";
    }
}
