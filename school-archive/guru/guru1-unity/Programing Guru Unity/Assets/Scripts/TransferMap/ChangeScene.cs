using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public GameObject menuFirst;
    public GameObject menuSecond;

    

    public void onBtnClickStart()
    {
        SceneManager.LoadScene("Start Scene");
    }

    //���� ��ư
    public void onBtnClickName()
    {
        SceneManager.LoadScene("Name Scene");
    }

    public void onBtnClickManual()
    {
        SceneManager.LoadScene("Manual Scene");
    }

    public void onBtnClickPrologue()
    {
        SceneManager.LoadScene("EventScene1");
    }

    //���� ��ư
    public static void onBtnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void onBtnClickPlay()
    {
        SceneManager.LoadScene("PlayerRoom");
    }

    
    // Start is called before the first frame update
    void Start()
    {
        SaveCheck();
    }

    //���� ���� ���۽� PlayerPrefs�� ���� ����(������Ʈ�� �ʱ�ȭ)
    public void GameNewStart()
    {
        PlayerPrefs.DeleteAll();
    }

    //���̺� üũ, ù ȭ�鿡�� ���̺갡 �Ǿ����� Ȯ��, ���̺갡 �Ǿ��ٸ� ���ν��۹�ư�� �߰��� ǥ��
    public void SaveCheck()
    {

        string Scene = SceneManager.GetActiveScene().name;

        if (Scene == "Start Scene")
        {
            if (PlayerPrefs.GetInt("SaveKey") != 1)
            {
                menuSecond.SetActive(false);
                menuFirst.SetActive(true);
            }
            else
            {
                menuFirst.SetActive(false);
                menuSecond.SetActive(true);
            }
        }
        else
            return;
    }
}
