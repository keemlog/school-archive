using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public bool isTriggered = false;

    [SerializeField]
    public Dialogue dialogue;

    private OpeningManager theEM;
    private GameManager theGM;

    void Start()
    {
        theEM = FindObjectOfType<OpeningManager>();
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
            }
        }

    }

    public void IsTriggered()
    {
        theGM.eventIndex = 0;
    }
}
