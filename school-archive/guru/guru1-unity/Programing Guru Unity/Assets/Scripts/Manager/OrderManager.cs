using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    private PlayerManager thePlayer;    //�̺�Ʈ ���� Ű�Է� ó�� ����
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = player.GetComponent<PlayerManager>();
    }

    public void Move(string _name, string _dir)
    {

    }

    public void NotMove()
    {
        thePlayer.canMove = false;
    }

    public void Move()
    {
        thePlayer.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
