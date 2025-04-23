using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Name : MonoBehaviour
{
    public string playerName = null;

    public InputField playerNameInput;
    public void onClickNameCheck()
    {
        playerName = playerNameInput.GetComponent<InputField>().text;
        SceneManager.LoadScene("Manual Scene");  //이후에 다음 씬으로 변경
        print(playerName);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
