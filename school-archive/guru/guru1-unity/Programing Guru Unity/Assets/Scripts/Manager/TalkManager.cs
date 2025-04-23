using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    
    void GenerateData() //대화 생성
    {

        // GenerateData() 사용법 :
        // 대화 추가 -> talkData.Add(오브젝트 번호, new string[] {" 넣어줄 대화 스크립트 "); 
        // # 오브젝트 번호는 100~ : NPC, 1000~ : 사물 등 오브젝트, 10000~ : 아이템


        //Object
        //PlayerRoom
        talkData.Add(1000, new string[] { "옷장이다." });
        talkData.Add(1100, new string[] { "협탁 위에 탁상시계가 있다.\n19xx년이라니... 정말 과거로 왔구나." });
        talkData.Add(1200, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(1300, new string[] { "내가 방금 일어난 침대다.", "할머니는 어디에 계신 걸까?" });
        talkData.Add(1400, new string[] { "책장이다. \n꽤나 오래 전 책들이 꽂혀 있다." });
        talkData.Add(1500, new string[] { "장난감 상자다." });

        //LivingRoom
        talkData.Add(2000, new string[] { "찬장이다." });
        talkData.Add(2100, new string[] { "요즘엔 보기 힘든 책들이 잔뜩 꽂혀 있다." });

        //MasterBedRoom
        talkData.Add(3000, new string[] { "할머니의 침대다." });

        //Library
        talkData.Add(4000, new string[] { "종이와 펜 등이 들어 있다." });

        //Yard


        //NPC
        talkData.Add(100, new string[] { "뭐 하고 있어?:0", "얼른 집을 둘러봐야지!:0",
                                                "자, 얼른 다시 가봐!:0","어휴 참... 알겠어! 가요 가!:1" });
        talkData.Add(200, new string[] { "현관문은 집 안에서 찾아야 할 물건을 전부 얻어야 열 수 있어.:0", "총 3개니까, 얼른 다시 찾아봐!:0","참, 그리고 마당에 무서운 강아지가 있더라. \n날 먹으려고 했어... 나갈 때 조심해!:0"});

        //Item
        talkData.Add(10000, new string[] { "하트를 주웠다." });
        talkData.Add(10100, new string[] { "장난감 상자다.\n할머니가 예전에 갖고 노시던 걸까?", "내가 아끼는 곰인형이랑 많이 닮았네... 그러고 보니 할머니가 주셨었지.",
                                            "일단 챙겨가자.","곰인형을 챙겼다." });   //곰인형
        talkData.Add(10200, new string[] { "화장대다.\n자세히 보니 할머니가 전에 주셨던 것과 똑같은 목걸이가 들어 있다.","할머니...","목걸이를 챙겼다." });   //목걸이
        talkData.Add(10300, new string[] { "책상이다. \n예쁜 자수가 놓인 손수건이 놓여 있다.", "뒷 면을 보니 할머니의 성함이 자수로 놓여 있다.", 
                                            "이것도 할머니가 주셨던 손수건이랑 똑같이 생겼어...","손수건을 챙겼다." });   //손수건
        talkData.Add(10400, new string[] { "어? 왜 이런 곳에 선물 상자가 있지?","상자 안을 보니, 할머니가 아까 입으셨던 한복과 똑같은 한복이 들어 있다.",
                                            "그러고 보니 전에 할아버지가 깜짝 선물을 주신 적이 있다고 하셨지.","아까 그 한복, 할아버지가 주셨던 옷이었구나...","정말 소중한 옷이셨을텐데 내가 너무 심하게 말했어...",
                                            "할머니... 죄송해요...\n얼른 보고 싶어요.","낡은 한복을 챙겼다." });   //낡은 한복

        //상호작용 용 아이템
        talkData.Add(10110, new string[] { "할머니의 곰인형.\n할머니가 주신 인형과 똑같이 생겼다." });
        talkData.Add(10210, new string[] { "할머니의 목걸이.\n할머니가 전에 나에게 주신 것과 똑같이 생겼다." });
        talkData.Add(10310, new string[] { "할머니의 손수건.\n뒷면에 할머니의 성함이 자수로 씌여 있다." });
        talkData.Add(10410, new string[] { "할머니의 예쁜 한복." });



        //Quest Talk
        talkData.Add(10 + 100, new string[] { "뭐 하고 있어?:0", "얼른 집을 둘러봐야지!:0",
                                                "자, 얼른 다시 가봐!:0","어휴 참... 알겠어! 가요 가!:1" });

        talkData.Add(20 + 100, new string[] { "첫 번째 추억은 찾았어?:0" , "이제 나머지도 찾아보러가.:0" });


        //Portrait
        portraitData.Add(100 + 0, portraitArr[0]);
        portraitData.Add(100 + 1, portraitArr[1]);

        portraitData.Add(200 + 0, portraitArr[2]);
        portraitData.Add(200 + 1, portraitArr[3]);

    }

    public string GetTalk(int id, int talkIndex)    //대화 반환
    {
        if (!talkData.ContainsKey(id))
        {
            Debug.Log(id - id % 10);
            if (!talkData.ContainsKey(id - id % 10))
            {
                //퀘스트 맨 처음 대사마저 없을 때
                //기본 대사를 가지고 온다.
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //해당 퀘스트 진행 순서 대사가 없을 때
                //퀘스트 맨 처음 대사를 가지고 온다.
                if (talkIndex == talkData[id - id % 10].Length)
                    return null;
                else
                    return talkData[id - id % 10][talkIndex];
            }
            
        }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

}
