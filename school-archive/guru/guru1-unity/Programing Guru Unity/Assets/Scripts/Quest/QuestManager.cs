using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList; 

    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestData("집을 조사하기", new int[] { 100 }));

        questList.Add(20, new QuestData("첫 번째 추억 찾기", new int[] { 100 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        string strRtn = questList[questId].questName;

        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();

        return strRtn;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}
