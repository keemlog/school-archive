using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    public GameObject evBack;

    public bool isTriggered = false;

    [SerializeField]
    public Dialogue dialogue;

    private EventManager theEM;
    private GameManager theGM;

    void Start()
    {
        theEM = FindObjectOfType<EventManager>();
        theGM = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered == false)
        {
            if (collision.gameObject.name == "Player")
            {
                theEM.ShowDialogue(dialogue);
                isTriggered = true;
                IsTriggered();
            }
        }

    }

    public void IsTriggered()
    {
        theGM.eventIndex = 1;
    }
}
