using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ClearTextBlink : MonoBehaviour
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

            flashingText.text = "Start Over";
            yield return new WaitForSeconds(.3f);
        }
    }
}
