using System;
using System.Collections;
using System.Collections.Generic;
using uMyGUI;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

[Serializable]
public class Excavator
{
    public int level = 1;
    public int time = 20;
    public int tick = 0;
    public bool startedFlag = false;
    public bool finishedFlag = false;

    public int CopperPerMin = 0;
    public int SilverPerMin = 0;
    public int GoldPerMin = 0;
    
    public Slider progressWheel;

    public void reset()
    {
        level = 1;
        time = 20;
        tick = 0;
        startedFlag = false;
        finishedFlag = false;

        CopperPerMin = 0;
        SilverPerMin = 0;
        GoldPerMin = 0;
    }
}
[Serializable]
public class Weapon
{
    public int level = 0;
    public float maxCharge = 4;
}

public class GameManager : MonoBehaviour {

    private static GameManager s_instance = null;
    public static GameManager Instance { get { return s_instance; } }

    private void Awake()
    {
        if (s_instance != null) Debug.LogError("GameManager already exists.");
        s_instance = this;
    }
    private void OnDestroy()
    {
        if (s_instance == this) s_instance = null;
    }

    // fps
    public CharacterController cc;
    public FirstPersonController fpc;
    public Camera fpsCam;
    public PlayerRaycast pr;
    public Transform StartGamePoint;

    // HUD
    public GameObject HUDCanvas;
    public Text copperText;
    public Text silverText;
    public Text goldText;
    public Text GunLevelText;

    // resources
    public Excavator[] ext;
    public Weapon gun;
    public int Copper = 0;
    public int Silver = 0;
    public int Gold = 0;
    
    // Use this for initialization
    void Start () {
        NewGame();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (uMyGUI_PopupManager.Instance.IsPopupShown)
            {
                uMyGUI_PopupManager.Instance.HideAllPopup();
                FreezPlayer(false);
                Unpause();
            }

            //pause game

            //freez player

            //show menu
        }
	}

    public void GameStart()
    {
        GunLevelText.text = "Weapon Level : " + gun.level;
        UIFloatManager.Instance.ShowUI(0);
    }
    public void NewGame()
    {
        ResetGame();
        GameStart();
    }
    public void ResetGame()
    {
        InventoryManager.Instance.End = false;

        ext[0].reset();
        ext[1].reset();

        gun = new Weapon();
        UpgradeWeapon();

        Copper = 0;
        Silver = 0;
        Gold = 0;
        UpdateResourceText();
        cc.transform.position = StartGamePoint.position;

        DoorsControl.Instance.CloseDoor(0);
        DoorsControl.Instance.CloseDoor(1);

        ExcavatorControl.Instance.ExcavatorOff(0);
        ExcavatorControl.Instance.ExcavatorOff(1);
    }
    public void GameOver()
    {
        FreezPlayer(true);
        ShowHUD(false);
    }
    public void SaveGame()
    {

    }
    public void LoadGame()
    {

    }
    public void StartExcavator(int index, int copper, int silver, int gold)
    {
        ext[index].CopperPerMin = copper;
        ext[index].SilverPerMin = silver;
        ext[index].GoldPerMin = gold;
        ext[index].startedFlag = true;
        
        StartCoroutine(ExcavatorProcess(index));
    }
    public void RestartExcavator(int index)
    {
        StartCoroutine(ExcavatorProcess(index));
    }
    IEnumerator ExcavatorProcess(int index)
    {
        Excavator e = ext[index];
        while(e.tick * 0.1f < e.time)
        {
            yield return new WaitForSeconds(0.1f);
            e.tick++;
            e.progressWheel.value = (e.tick * e.progressWheel.maxValue * 0.1f) / e.time;
        }
        e.tick = 0;
        ExcavatorControl.Instance.ExcavatorOff(index);
        e.finishedFlag = true;
        NotificationText.Instance.AddNotification("Excavator0" + (index+1) + " finish process.");
    }
    public void StopExcavator(int index)
    {
        ExcavatorControl.Instance.ExcavatorOff(index);
    }
    public void ShowHUD(bool toggle)
    {
        HUDCanvas.SetActive(toggle);
    }
    public void FreezPlayer(bool toggle)
    {
        cc.enabled = !toggle;
        fpc.enabled = !toggle;
        //fpsCam.enabled = !toggle;
        pr.enabled = !toggle;

        ShowHUD(!toggle);
        ShowCursor(toggle);
    }
    public void ShowCursor(bool toggle)
    {
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = toggle;
    }
    public void UpgradeWeapon()
    {
        gun.level += 1;
        gun.maxCharge = gun.maxCharge - (gun.level * 0.2f);
        GunLevelText.text = "Weapon Level : " + gun.level;
    }
    public void UpgradeExcavator(int index)
    {
        float copper = ext[index].CopperPerMin;
        float silver = ext[index].SilverPerMin;
        float gold = ext[index].GoldPerMin;
        copper *= 1.1f;
        silver *= 1.1f;
        gold *= 1.1f;
        ext[index].CopperPerMin = (int)copper;
        ext[index].SilverPerMin = (int)silver;
        ext[index].GoldPerMin = (int)gold;
        ext[index].level += 1;
    }
    public void AddCopper(int amount)
    {
        Copper += amount;
        UpdateResourceText();
    }
    public void AddSilver(int amount)
    {
        Silver += amount;
        UpdateResourceText();
    }
    public void AddGold(int amount)
    {
        Gold += amount;
        UpdateResourceText();
    }
    public void RemoveCopper(int amount)
    {
        Copper -= amount;
        if (Copper < 0) Copper = 0;
        UpdateResourceText();
    }
    public void RemoveSilver(int amount)
    {
        Silver -= amount;
        if (Silver < 0) Silver = 0;
        UpdateResourceText();
    }
    public void RemoveGold(int amount)
    {
        Gold -= amount;
        if (Gold < 0) Gold = 0;
        UpdateResourceText();
    }
    void UpdateResourceText()
    {
        copperText.text = "Copper : " + Copper;
        silverText.text = "Silver : " + Silver;
        goldText.text = "Gold : " + Gold;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Unpause()
    {
        Time.timeScale = 1;
    }
}