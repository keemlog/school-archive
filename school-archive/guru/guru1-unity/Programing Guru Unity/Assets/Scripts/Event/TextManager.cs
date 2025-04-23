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

    // ��ȭ ���� ����ü
    [System.Serializable]
    public struct ConversationLine
    {
        public string speaker; // ȭ���� �̸�
        [TextArea(3, 10)]
        public string text;    // ��ȭ ����
        public Sprite characterSprite; // ȭ���� ĳ���� ��������Ʈ
    }

    public ConversationLine[] conversationLines; // ��ȭ ���� �迭
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
                theAudio.Play(typeSound);   //Ÿ�̹� ����
            }
            yield return new WaitForSeconds(0.05f); // Ÿ���� �ӵ� ����
        }

        isTyping = false;
        canProceed = true;
    }

    IEnumerator TransitionToNextScene()
    {
        yield return new WaitForSeconds(1.0f);

        // ���� �� �̸��� ���� ���� ������ ��ȯ
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
                // Ÿ���� �߿� �����̽��ٸ� ������ ��ü �ؽ�Ʈ�� �� ���� ǥ��
                StopAllCoroutines();
                dialogueText.text = conversationLines[currentIndex].text;
                isTyping = false;
                canProceed = true; // Ÿ���� �߿� �����̽��ٸ� ������ ��ȭ�� �ٷ� ������ �� �ֵ��� ����
            }
            else if (canProceed)
            {
                // ��ȭ ����
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
                    // ��ȭ�� ������ ���� ������ ��ȯ
                    background.SetActive(true);
                    StartCoroutine(TransitionToNextScene());
                }
            }
        }
    }
}
