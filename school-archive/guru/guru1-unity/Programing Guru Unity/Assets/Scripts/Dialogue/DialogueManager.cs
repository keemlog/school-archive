using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private GameManager gManager;
    public TalkManager talkManager;
    public QuestManager questManager;

    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton


    public TypeEffect text;
    public Image portraitImg;
    public Animator talkPanel;
    public Animator portraitAnim;
    public GameObject scanObject;

    public SpriteRenderer rendererSprite;
    public SpriteRenderer rendererDialogueWindow;

    public Sprite prePortrait;

    private int count; //대화 진행 상황 카운트
    public bool isAction;
    public bool isSlot = false;
    public bool isQuestItem;

    public Animator animSprite;
    public Animator animDialogueWindow;

    public Inventory inven;


    public void Action(GameObject scanObj)
    {
        //액션 컨트롤 -> Talk로 위임
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        isAction = Talk(objData.id, objData.isNpc, objData.isQuestItem);

        talkPanel.SetBool("isShow",isAction);

    }
    public void ActionForItem(int itemcode)
    {
        isAction = Talk(itemcode, false, false);

        talkPanel.SetBool("isShow", isAction);
    }

    public void EndAction()
    {
        talkPanel.SetBool("isShow", false);
    }

    public bool Talk(int id, bool isNpc, bool isQuestItem)
    {
        string talkData = "";

        if (text.isAnim)
        {
            text.SetMsg("");
            return true;
        }
        else
        {
            talkData = talkManager.GetTalk(id, count);
        }

        //End Talk
        if (talkData == null)
        {
            isAction = false;
            count = 0;
            if(isQuestItem)
                inven.GetItem();
            return false;
        }

        
        if (isNpc)
        {
            text.SetMsg(talkData.Split(':')[0]);

            rendererSprite.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            rendererSprite.color = new Color(1, 1, 1, 1);
            //portraitImg.color = new Color(1, 1, 1, 1);
            
            //Animation Portrait
            if(prePortrait != rendererSprite.sprite)
            {
                portraitAnim.SetTrigger("doEffect");
                prePortrait = rendererSprite.sprite;
            }
        }
        else
        {
            text.SetMsg(talkData);

            rendererSprite.color = new Color(1, 1, 1, 0);
            //portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        count++;

        return true;
    }
}
