using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    
    public InputField playerNameInput;
    public static string playerName = null;

    private void Start()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
    }

    private void Update()
    {
        if (playerName.Length > 0 && Input.GetButtonDown("Jump"))
        {
            InputName();
        }
    }

    public void InputName()
    {
        playerName = playerNameInput.text + "";
        PlayerPrefs.SetString("PlayerName", playerName);
        Debug.Log(playerName);
    }
}
