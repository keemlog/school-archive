using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect_Event : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject EndCursor;

    Text msgText;
    AudioSource audioSource;

    string targetMsg;
    int index;
    float interval;
    float delayTime;
    public bool isAnim;


    private void Awake()
    {
        msgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        msgText.text = "";
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            //delayTime = 1.0f / 4;
            EffectStart();
            //Invoke("EffectStart", delayTime);

        }
    }

    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        //Start Animation
        interval = 1.0f / CharPerSeconds;
        isAnim = true;
        Invoke("Effecting", interval); //시간차 반복 호출을 위한 Invoke 사용
    }

    void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];

        //Sound
        if (targetMsg[index] != ' ' && targetMsg[index] != '.')
            audioSource.Play();

        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        EndCursor.SetActive(true);
        isAnim = false;
        CancelInvoke();
    }

}
