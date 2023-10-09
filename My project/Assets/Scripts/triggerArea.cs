using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eventType
{
    animation,
    music,
    combat,
    unityevent,
}

[System.Serializable]
public class eventTypeClass
{
    public eventType type;
    public GameObject target;
    public string name;
    public AudioClip clip;
    public AudioSource audioSource;
    public combatContoller contoller;
    public CustomEvent customEvent;
    public bool test;

    public void Activate()
    {
        if (type == eventType.animation)
        {
            target.GetComponent<Animator>().SetTrigger(name);
            return;
        }
        if (type == eventType.music)
        {
            audioSource.clip = clip;
            audioSource.Play();
            return;
        }
        if (type == eventType.combat)
        {
            contoller.StartCombat();
            return;
        }
        if (type == eventType.unityevent)
        {
            customEvent.Invoke(target);
        }
    }
}

public class triggerArea : MonoBehaviour
{
    public eventTypeClass[] events;

    public void Activate()
    {
        foreach (eventTypeClass type in events)
        {
            type.Activate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            Activate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Activate();
        }
    }
}
