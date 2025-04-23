using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCMove
{
    [Tooltip("NPCmove�� üũ�ϸ� NPC�� ������")]
    public bool NPCmove;

    public string[] direction;  //npc�� ������ ���� ����

    [Range(1,5)] [Tooltip("1 = õõ��, 3 = ����, 5 = ����������")]
    public int frequency;   //npc�� ������ �������� �󸶳� ���� �ӵ��� ������ ���ΰ�
}

public class NPCManager : PlayerMove
{
    [SerializeField]
    public NPCMove npc;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    public void SetMove()
    {
        
    }

    public void SetNotMove()
    {

    }

    IEnumerator MoveCoroutine()
    {
        if(npc.direction.Length != 0)
        {
            for(int i = 0; i < npc.direction.Length; i++)
            {
                switch (npc.frequency)
                {
                    case 1:
                        yield return new WaitForSeconds(4f);
                        break;

                    case 2:
                        yield return new WaitForSeconds(3f);
                        break;

                    case 3:
                        yield return new WaitForSeconds(2f);
                        break;

                    case 4:
                        yield return new WaitForSeconds(1f);
                        break;

                    case 5:
                        break;
                }

                base.Move(npc.direction[i]);

                if(i == npc.direction.Length - 1)
                {
                    i = -1;
                }
            }
        }
    }
}
