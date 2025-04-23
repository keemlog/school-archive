using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNameUI : MonoBehaviour
{
    public GameObject UI;
    public GameObject[] preUI = new GameObject[6];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            for(int i=0;i<6;i++)
                preUI[i].SetActive(false);
            UI.SetActive(true);
            Debug.Log(collision.gameObject.name);

        }

    }
}
