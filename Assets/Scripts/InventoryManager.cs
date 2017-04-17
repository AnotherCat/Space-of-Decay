using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour {

    private static InventoryManager s_instance = null;
    public static InventoryManager Instance
    {
        get { return s_instance; }
    }
    private void Awake()
    {
        if(s_instance != null)
        {
            Debug.LogError("InventoryManager already an instance.");
        }
        s_instance = this;
    }
    private void OnDestroy()
    {
        if (s_instance == this) s_instance = null;
    }

    public enum Slot
    {
        INVENTORY,
        RED_KEYCARD,
        GREEN_KEYCARD,
        CONTROL_CHIP,
        ENGINES,
        NAVIGATOR,
        FUEL,
        CONTROL_CHIP1,
        CONTROL_CHIP2,
        CONTROL_CHIP3,
        NAVIGATOR1,
        NAVIGATOR2,
        NAVIGATOR3,
        ENGINES1,
        ENGINES2,
        ENGINES3,
        FUEL1,
        FUEL2,
        FUEL3
    }

    public RectTransform[] m_item = new RectTransform[0];

    public void Start()
    {
        ResetItem();
    }

    public void ResetItem()
    {
        for(int i = 0; i < m_item.Length; i++)
        {
            m_item[i].gameObject.SetActive(false);
        }
    }

    public void AddItem(int index)
    {
        m_item[index].gameObject.SetActive(true);
    }
    public void RemoveItem(int index)
    {
        m_item[index].gameObject.SetActive(false);
    }
    public bool HasItem(int index)
    {
        return m_item[index].gameObject.activeSelf;
    }

    public void OnDropItem(Slot item,Slot dropzone)
    {
        Debug.Log("Boom!!! <" + item + "> PLACED ON DROPZONE <" + dropzone + ">");
        if(item == Slot.RED_KEYCARD && dropzone == Slot.RED_KEYCARD)
        {
            DoorsControl.Instance.locked[0] = false;
            NotificationText.Instance.AddNotification("Door1 Unlocked");
        }
    }

    public void OnDragItem(Slot item,Slot dropzone)
    {
        Debug.Log("BAM!!! <" + item + "> DRAG OUT FROM DROPZONE <" + dropzone + ">");
    }
}
