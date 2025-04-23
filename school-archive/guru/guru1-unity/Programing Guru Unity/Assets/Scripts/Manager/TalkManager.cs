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

    
    void GenerateData() //��ȭ ����
    {

        // GenerateData() ���� :
        // ��ȭ �߰� -> talkData.Add(������Ʈ ��ȣ, new string[] {" �־��� ��ȭ ��ũ��Ʈ "); 
        // # ������Ʈ ��ȣ�� 100~ : NPC, 1000~ : �繰 �� ������Ʈ, 10000~ : ������


        //Object
        //PlayerRoom
        talkData.Add(1000, new string[] { "�����̴�." });
        talkData.Add(1100, new string[] { "��Ź ���� Ź��ð谡 �ִ�.\n19xx���̶��... ���� ���ŷ� �Ա���." });
        talkData.Add(1200, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(1300, new string[] { "���� ��� �Ͼ ħ���.", "�ҸӴϴ� ��� ��� �ɱ�?" });
        talkData.Add(1400, new string[] { "å���̴�. \n�ϳ� ���� �� å���� ���� �ִ�." });
        talkData.Add(1500, new string[] { "�峭�� ���ڴ�." });

        //LivingRoom
        talkData.Add(2000, new string[] { "�����̴�." });
        talkData.Add(2100, new string[] { "���� ���� ���� å���� �ܶ� ���� �ִ�." });

        //MasterBedRoom
        talkData.Add(3000, new string[] { "�ҸӴ��� ħ���." });

        //Library
        talkData.Add(4000, new string[] { "���̿� �� ���� ��� �ִ�." });

        //Yard


        //NPC
        talkData.Add(100, new string[] { "�� �ϰ� �־�?:0", "�� ���� �ѷ�������!:0",
                                                "��, �� �ٽ� ����!:0","���� ��... �˰ھ�! ���� ��!:1" });
        talkData.Add(200, new string[] { "�������� �� �ȿ��� ã�ƾ� �� ������ ���� ���� �� �� �־�.:0", "�� 3���ϱ�, �� �ٽ� ã�ƺ�!:0","��, �׸��� ���翡 ������ �������� �ִ���. \n�� �������� �߾�... ���� �� ������!:0"});

        //Item
        talkData.Add(10000, new string[] { "��Ʈ�� �ֿ���." });
        talkData.Add(10100, new string[] { "�峭�� ���ڴ�.\n�ҸӴϰ� ������ ���� ��ô� �ɱ�?", "���� �Ƴ��� �������̶� ���� ��ҳ�... �׷��� ���� �ҸӴϰ� �ּ̾���.",
                                            "�ϴ� ì�ܰ���.","�������� ì���." });   //������
        talkData.Add(10200, new string[] { "ȭ����.\n�ڼ��� ���� �ҸӴϰ� ���� �̴ּ� �Ͱ� �Ȱ��� ����̰� ��� �ִ�.","�ҸӴ�...","����̸� ì���." });   //�����
        talkData.Add(10300, new string[] { "å���̴�. \n���� �ڼ��� ���� �ռ����� ���� �ִ�.", "�� ���� ���� �ҸӴ��� ������ �ڼ��� ���� �ִ�.", 
                                            "�̰͵� �ҸӴϰ� �̴ּ� �ռ����̶� �Ȱ��� �����...","�ռ����� ì���." });   //�ռ���
        talkData.Add(10400, new string[] { "��? �� �̷� ���� ���� ���ڰ� ����?","���� ���� ����, �ҸӴϰ� �Ʊ� �����̴� �Ѻ��� �Ȱ��� �Ѻ��� ��� �ִ�.",
                                            "�׷��� ���� ���� �Ҿƹ����� ��¦ ������ �ֽ� ���� �ִٰ� �ϼ���.","�Ʊ� �� �Ѻ�, �Ҿƹ����� �̴ּ� ���̾�����...","���� ������ ���̼����ٵ� ���� �ʹ� ���ϰ� ���߾�...",
                                            "�ҸӴ�... �˼��ؿ�...\n�� ���� �;��.","���� �Ѻ��� ì���." });   //���� �Ѻ�

        //��ȣ�ۿ� �� ������
        talkData.Add(10110, new string[] { "�ҸӴ��� ������.\n�ҸӴϰ� �ֽ� ������ �Ȱ��� �����." });
        talkData.Add(10210, new string[] { "�ҸӴ��� �����.\n�ҸӴϰ� ���� ������ �ֽ� �Ͱ� �Ȱ��� �����." });
        talkData.Add(10310, new string[] { "�ҸӴ��� �ռ���.\n�޸鿡 �ҸӴ��� ������ �ڼ��� ���� �ִ�." });
        talkData.Add(10410, new string[] { "�ҸӴ��� ���� �Ѻ�." });



        //Quest Talk
        talkData.Add(10 + 100, new string[] { "�� �ϰ� �־�?:0", "�� ���� �ѷ�������!:0",
                                                "��, �� �ٽ� ����!:0","���� ��... �˰ھ�! ���� ��!:1" });

        talkData.Add(20 + 100, new string[] { "ù ��° �߾��� ã�Ҿ�?:0" , "���� �������� ã�ƺ�����.:0" });


        //Portrait
        portraitData.Add(100 + 0, portraitArr[0]);
        portraitData.Add(100 + 1, portraitArr[1]);

        portraitData.Add(200 + 0, portraitArr[2]);
        portraitData.Add(200 + 1, portraitArr[3]);

    }

    public string GetTalk(int id, int talkIndex)    //��ȭ ��ȯ
    {
        if (!talkData.ContainsKey(id))
        {
            Debug.Log(id - id % 10);
            if (!talkData.ContainsKey(id - id % 10))
            {
                //����Ʈ �� ó�� ��縶�� ���� ��
                //�⺻ ��縦 ������ �´�.
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //�ش� ����Ʈ ���� ���� ��簡 ���� ��
                //����Ʈ �� ó�� ��縦 ������ �´�.
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
