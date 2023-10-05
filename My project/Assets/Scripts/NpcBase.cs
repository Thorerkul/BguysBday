using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcBase : MonoBehaviour
{
    public DialogueTrigger trigger;
    public GameObject prompt;
    public bool showPrompt;

    private void Update()
    {
        prompt.SetActive(showPrompt);
    }
}
