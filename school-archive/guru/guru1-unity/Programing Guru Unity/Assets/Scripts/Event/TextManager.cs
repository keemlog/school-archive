using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image characterImage;

    public GameObject background;

    // 대화 정보 구조체
    [System.Serializable]
    public struct ConversationLine
    {
        public string speaker; // 화자의 이름
        [TextArea(3, 10)]
        public string text;    // 대화 내용
        public Sprite characterSprite; // 화자의 캐릭터 스프라이트
    }

    public ConversationLine[] conversationLines; // 대화 정보 배열
    private int currentIndex = 0;
    private bool isTyping = false;
    private bool canProceed = false;

    public AudioManager theAudio;
    public string typeSound;

    void Start()
    {
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        canProceed = false;

        string currentText = "";
        string fullText = conversationLines[currentIndex].text;

        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            dialogueText.text = currentText;
            if (i % 2 == 1)
            {
                theAudio.Play(typeSound);   //타이밍 사운드
            }
            yield return new WaitForSeconds(0.05f); // 타이핑 속도 조절
        }

        isTyping = false;
        canProceed = true;
    }

    IEnumerator TransitionToNextScene()
    {
        yield return new WaitForSeconds(1.0f);

        // 현재 씬 이름에 따라 다음 씬으로 전환
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "EventScene1")
        {
            SceneManager.LoadScene("EventScene2");
        }
        else if (currentSceneName == "EventScene2")
        {
            SceneManager.LoadScene("PlayerRoom");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                // 타이핑 중에 스페이스바를 누르면 전체 텍스트를 한 번에 표시
                StopAllCoroutines();
                dialogueText.text = conversationLines[currentIndex].text;
                isTyping = false;
                canProceed = true; // 타이핑 중에 스페이스바를 누르면 대화를 바로 진행할 수 있도록 설정
            }
            else if (canProceed)
            {
                // 대화 진행
                canProceed = false;
                currentIndex++;

                if (currentIndex < conversationLines.Length)
                {
                    StartCoroutine(TypeText());
                    nameText.text = conversationLines[currentIndex].speaker;
                    characterImage.sprite = conversationLines[currentIndex].characterSprite;
                }
                else
                {
                    // 대화가 끝나면 다음 씬으로 전환
                    background.SetActive(true);
                    StartCoroutine(TransitionToNextScene());
                }
            }
        }
    }
}
