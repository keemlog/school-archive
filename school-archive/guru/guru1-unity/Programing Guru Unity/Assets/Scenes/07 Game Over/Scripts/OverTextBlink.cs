using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OverTextBlink : MonoBehaviour
{
    Text flashingText;
    // Use this for initialization

    void Start()
    {
        flashingText = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            flashingText.text = "";
            yield return new WaitForSeconds(.3f);

            flashingText.text = "Try Again?";
            yield return new WaitForSeconds(.3f);
        }
    }
}

