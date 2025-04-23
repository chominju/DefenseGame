using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour, IPointerClickHandler
{
    public static GameObject clickItem;  // 클릭 된 아이템

    public void OnPointerClick(PointerEventData eventData)
    {
        //if (clickItem == null || clickItem != gameObject)
        //{
        //    // 클릭을 처음하거나, 새로운 아이템을 클릭함.
        //    SoundManager.GetInstance().PlayItemClickSound();
        //    clickItem = gameObject;
        //    Debug.Log("오브젝트 처음or 새로운거 클릭됨 : " + clickItem.name);
        //    if (clickItem.GetComponent<Item>().IsBox())
        //        ExplainUI.instacne.SetIsBox(true);
        //    else
        //        ExplainUI.instacne.SetIsBox(false);
        //}
        //else
        //{
        //    // 기존에 클릭했던 아이템을 또 클릭함.

        //    if (clickItem.GetComponent<Item>().IsBox())
        //    {
        //        int quantity = clickItem.GetComponent<Item>().GetQuantity();
        //        int getStamina = DataManager.GetDataManager().GetStaminaData();
        //        if (quantity > 0 && getStamina > 0)
        //        {
        //            string ItemType = clickItem.GetComponent<Item>().GetItemTypeName();
        //            string ItemName = clickItem.GetComponent<Item>().GetItemName();
        //            int level = clickItem.GetComponent<Item>().GetItemLevel();
        //            InventoryManager.instacne.CreateItem(ItemType, level);
        //            Debug.Log("오브젝트 기존꺼(박스o, 수량o) 클릭됨  : " + clickItem.name);
        //        }
        //        else
        //        {
        //            SoundManager.GetInstance().PlayFailSound();
        //            Debug.Log("오브젝트 기존꺼(박스o, 수량x) 클릭됨 : " + clickItem.name);
        //        }
        //    }
        //    else
        //    {
        //        SoundManager.GetInstance().PlayItemClickSound();
        //        Debug.Log("오브젝트 기존꺼(박스x) 클릭됨 : " + clickItem.name);
        //    }
        //}

        //// 클릭된 아이템에 대한 정보 수정.
        //Sprite itemSprite = clickItem.GetComponent<Item>().GetSprite();
        //string itemShowName = clickItem.GetComponent<Item>().GetItemShowName();
        //string itemTypeName = clickItem.GetComponent<Item>().GetItemTypeName();
        //int itemLevel = clickItem.GetComponent<Item>().GetItemLevel();
        //string itemExplain = clickItem.GetComponent<Item>().GetExplain();
        //int itemMaxLevel = clickItem.GetComponent<Item>().GetMaxLevel();
        //int itemSellGold = clickItem.GetComponent<Item>().GetSellPrice();

        //ExplainUI.instacne.SetBackgroundPanel(true);
        //ExplainUI.instacne.SetItemImage(itemSprite);
        //ExplainUI.instacne.SetItemTypeName(itemTypeName);
        //ExplainUI.instacne.SetItemMaxLevel(itemMaxLevel);
        //ExplainUI.instacne.SetItemExplain(itemShowName, itemLevel, itemExplain, itemSellGold);
    }

}
