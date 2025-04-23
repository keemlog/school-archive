using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion


    public List<Item> items = new List<Item>();
    PlayerManager pManager;
    public InventoryUI invui;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    FieldItems fieldItems;


    public bool AddItem(Item _item)
    {
        if (items.Count < 7)
        {
            items.Add(_item);
            invui.RedrawSlotUI();

            switch (items.Count)
            {
                case 1:
                    PlayerPrefs.SetString("Item1",_item.itemName);
                    break;
                case 2:
                    PlayerPrefs.SetString("Item2", _item.itemName);
                    break;
                case 3:
                    PlayerPrefs.SetString("Item3", _item.itemName);
                    break;
                case 4:
                    PlayerPrefs.SetString("Item4", _item.itemName);
                    break;
            }

            return true;
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            Debug.Log("È®ÀÎ");
            fieldItems = collision.GetComponent<FieldItems>();

        }
    }

    public void GetItem()
    {
        if (AddItem(fieldItems.GetItem()))
            fieldItems.DestroyItem();
    }

    public int GetItemCount()
    {
        return items.Count;
    }
    
}
