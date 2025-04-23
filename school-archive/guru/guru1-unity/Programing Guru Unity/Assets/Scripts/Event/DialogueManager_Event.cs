using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager_Event : MonoBehaviour
{
    public static DialogueManager_Event instance;
    private GameManager gManager;
    public TalkManager talkManager;

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

    public Animator animSprite;
    public Animator animDialogueWindow;


    private void Start()
    {
        
    }

    public void Action(GameObject scanObj)
    {
        //액션 컨트롤 -> Talk로 위임
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        isAction = Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow",isAction);
    }

    public bool Talk(int id, bool isNpc)
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

        if (talkData == null)
        {
            isAction = false;
            count = 0;
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
