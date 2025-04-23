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

    //시작 버튼
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

    //종료 버튼
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

    //게임 새로 시작시 PlayerPrefs를 전부 삭제(레지스트리 초기화)
    public void GameNewStart()
    {
        PlayerPrefs.DeleteAll();
    }

    //세이브 체크, 첫 화면에서 세이브가 되었는지 확인, 세이브가 되었다면 새로시작버튼을 추가로 표시
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
