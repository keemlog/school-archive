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
        SceneManager.LoadScene("Manual Scene");  //���Ŀ� ���� ������ ����
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
