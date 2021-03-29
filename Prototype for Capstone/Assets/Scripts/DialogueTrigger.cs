using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public float amountToDelayStartBy;

    public void Start()
    {
       StartCoroutine(TriggerDialogue());
    }

    public IEnumerator TriggerDialogue()
    {
        yield return new WaitForSeconds(amountToDelayStartBy);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
