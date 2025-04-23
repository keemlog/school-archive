using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject menuSet;

    public GameObject player;

    public Image portraitImg;
    public Text talkText;
    public GameObject talkPanel;
    public GameObject scanObject;

    public TalkManager talkManager;
    private CameraManager theCamera;
    public DialogueManager dManager;

    public Inventory inven;
    public Item item11;
    public Item item21;
    public Item item31;
    public Item item41;

    public AudioSource audioSource;

    public bool isAction;
    public int talkIndex;
    public int eventIndex;

    public GameObject isClear;
    public GameObject isClear2;

    public GameObject prologue;
    public GameObject livingroom;

    public Text nameText1;
    public Text nameText2;
    public string nameName;


    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        print("Start");

        nameName = PlayerPrefs.GetString("PlayerName");
        if(nameName != "")
        {
            nameText1.text = nameName + "의 방";
            nameText2.text = nameName + "의 방";
        }
        GameLoad();
    }


    void Update()
    {
        //ESC를 눌렀을 때 나오는 창
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                audioSource.Play();
            }
            else
                menuSet.SetActive(true);
        }

        int inventoryItem = inven.GetItemCount();

        //인벤토리의 아이템 개수가 3이면 현관문이 열림
        if (inventoryItem >= 3)
        {
            isClear.SetActive(true);

            //4일 경우 마당 문 열림
            if (inventoryItem == 4)
            {
                Debug.Log(inventoryItem);
                isClear2.SetActive(true);
            }
        }
        
    }

    public void GameSave()
    {
        Scene scene = SceneManager.GetActiveScene();

        //세이브 된 적이 있는지 확인하는 용도, 1이면 있음
        PlayerPrefs.SetInt("SaveKey", 1);

        //카메라의 위치
        PlayerPrefs.SetFloat("CameraX", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CameraY", Camera.main.transform.position.y);
        //PlayerPrefs.SetString("Bound", bound);

        //플레이어의 위치
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetString("PlayerMap", scene.name);

        // + 현재까지 얻은 아이템 목록

        // + 퀘스트 진행도

        // 스토리 진행도
        PlayerPrefs.SetInt("Event", eventIndex);
        Debug.Log(eventIndex);


        PlayerPrefs.Save();

        menuSet.SetActive(false);

        Debug.Log("Save");
    }

    public void GameLoad()
    {
        if (PlayerPrefs.GetInt("SaveKey") != 1 || !PlayerPrefs.HasKey("SaveKey"))
            return;

        float camX = PlayerPrefs.GetFloat("CameraX");
        float camY = PlayerPrefs.GetFloat("CameraY");

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        eventIndex = PlayerPrefs.GetInt("Event");

        switch (eventIndex)
        {
            case 1:
                prologue.SetActive(false);
                break;

            case 2:
                prologue.SetActive(false);
                livingroom.SetActive(false);
                break;
        }

        string item1 = PlayerPrefs.GetString("Item1");
        string item2 = PlayerPrefs.GetString("Item2");
        string item3 = PlayerPrefs.GetString("Item3");

        switch (item1)
        {
            case "TeddyBear" :
                inven.AddItem(item11);
                break;
            case "Necklace":
                inven.AddItem(item21);
                break;
            case "Handkerchief":
                inven.AddItem(item31);
                break;

        }
        switch (item2)
        {
            case "TeddyBear":
                inven.AddItem(item11);
                break;
            case "Necklace":
                inven.AddItem(item21);
                break;
            case "Handkerchief":
                inven.AddItem(item31);
                break;

        }
        switch (item3)
        {
            case "TeddyBear":
                inven.AddItem(item11);
                break;
            case "Necklace":
                inven.AddItem(item21);
                break;
            case "Handkerchief":
                inven.AddItem(item31);
                break;

        }
        if(PlayerPrefs.HasKey("Item4"))
            inven.AddItem(item41);

        theCamera.transform.position = new Vector3(x, y, -10);
        player.transform.position = new Vector3(x, y, -1);
    }

    public void GameExit()
    {
        Application.Quit();
    }



}
