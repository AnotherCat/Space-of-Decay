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

    bool[] controlchip = new bool[3] { false, false, false };
    bool[] navigator = new bool[3] { false, false, false };
    bool[] engine = new bool[3] { false, false, false };
    bool[] fuel = new bool[3] { false, false, false };

    bool[] endgame = new bool[4] { false, false, false ,false};

    public void OnDropItem(Slot item,Slot dropzone)
    {
        Debug.Log("Boom!!! <" + item + "> PLACED ON DROPZONE <" + dropzone + ">");
        if(item == Slot.CONTROL_CHIP1)
        {
            controlchip[0] = true;
            ControlChipResult();
        }
        else if (item == Slot.CONTROL_CHIP2)
        {
            controlchip[1] = true;
            ControlChipResult();
        }
        else if (item == Slot.CONTROL_CHIP3)
        {
            controlchip[2] = true;
            ControlChipResult();
        }else if(item == Slot.NAVIGATOR1)
        {
            navigator[0] = true;
            NavigatorResult();
        }
        else if (item == Slot.NAVIGATOR2)
        {
            navigator[1] = true;
            NavigatorResult();
        }
        else if (item == Slot.NAVIGATOR3)
        {
            navigator[2] = true;
            NavigatorResult();
        }
        else if(item == Slot.ENGINES1)
        {
            engine[0] = true;
            EngineResult();
        }
        else if (item == Slot.ENGINES2)
        {
            engine[1] = true;
            EngineResult();
        }
        else if (item == Slot.ENGINES3)
        {
            engine[2] = true;
            EngineResult();
        }
        else if(item == Slot.FUEL1)
        {
            fuel[0] = true;
            FuelResult();
        }
        else if (item == Slot.FUEL2)
        {
            fuel[1] = true;
            FuelResult();
        }
        else if (item == Slot.FUEL3)
        {
            fuel[2] = true;
            FuelResult();
        }
        else if (item == Slot.CONTROL_CHIP)
        {
            endgame[0] = true;
            EndgameResult();
        }
        else if(item == Slot.NAVIGATOR)
        {
            endgame[1] = true;
            EndgameResult();
        }
        else if(item == Slot.ENGINES)
        {
            endgame[2] = true;
            EndgameResult();
        }
        else if (item == Slot.FUEL)
        {
            endgame[3] = true;
            EndgameResult();
        }
    }

    public void OnDragItem(Slot item,Slot dropzone)
    {
        Debug.Log("BAM!!! <" + item + "> DRAG OUT FROM DROPZONE <" + dropzone + ">");
    }

    void ControlChipResult()
    {
        if(controlchip[0] == true && controlchip[1] == true && controlchip[2] == true )
        {
            AddItem(2);
            NotificationText.Instance.AddNotification("<Control Chip> Added!!!");
            EnemyManager.Instance.AddEnemy();
        }
    }
    void NavigatorResult()
    {
        if(navigator[0] == true && navigator[1] == true && navigator[2] == true)
        {
            AddItem(3);
            NotificationText.Instance.AddNotification("<Navigator> Added!!!");
            EnemyManager.Instance.AddEnemy();
        }
    }
    void EngineResult()
    {
        if(engine[0] == true && engine[1] == true && engine[2] == true)
        {
            AddItem(4);
            NotificationText.Instance.AddNotification("<Engine> Added!!!");
            EnemyManager.Instance.AddEnemy();
        }
    }
    void FuelResult()
    {
        if(fuel[0] == true && fuel[1] == true && fuel[2] == true)
        {
            AddItem(5);
            NotificationText.Instance.AddNotification("<Fuel> Added!!!");
            EnemyManager.Instance.AddEnemy();
        }
    }
    void EndgameResult()
    {
        if(endgame[0] == true && endgame[1] == true && endgame[2] == true && endgame[3] == true)
        {
            NotificationText.Instance.AddNotification("BOOM!!! END GAME!!!");
        }
    }
}
