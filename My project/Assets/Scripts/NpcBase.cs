using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NpcBase : MonoBehaviour
{
    public GameObject prompt;
    public bool showPrompt;
    public bool isInDialogue;

    public NPCConversation conversation;
    public GameObject conversationManager;

    public void EnterDialogue()
    {
        conversationManager.SetActive(true);
        ConversationManager.Instance.StartConversation(conversation);
        isInDialogue = true;
    }

    public void ExitDialogue()
    {
        isInDialogue = false;
    }

    private void Update()
    {
        prompt.SetActive(showPrompt);
    }
}
