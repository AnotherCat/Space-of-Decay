using System.Collections;
using System.Collections.Generic;
using uMyGUI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Excavator
{
    public int level = 1;
    public int CopperPerMin = 0;
    public int SilverPerMin = 0;
    public int GoldPerMin = 0;

    public int CopperPool = 0;
    public int SilverPool = 0;
    public int GoldPool = 0;
}

public class Weapon
{
    public int Damage;
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    // fps
    public CharacterController cc;
    public FirstPersonController fpc;
    public Camera fpsCam;
    public PlayerRaycast pr;
    public Transform StartGamePoint;

    // HUD
    public GameObject HUDCanvas;

    // resources
    Excavator[] ext;
    Weapon gun;
    public int Copper = 0;
    public int Silver = 0;
    public int Gold = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

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

    }
    public void NewGame()
    {
        ResetGame();
        GameStart();
    }
    public void ResetGame()
    {
        ext = new Excavator[2];
        ext[0] = new Excavator();
        ext[1] = new Excavator();

        gun = new Weapon();

        Copper = 0;
        Silver = 0;
        Gold = 0;

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
        StartCoroutine(ExcavatorProcess(index));
    }
    IEnumerator ExcavatorProcess(int index)
    {
        yield return new WaitForSeconds(5);
        ExcavatorControl.Instance.ExcavatorOff(index);
        Excavator e = ext[index];
        e.CopperPool += e.CopperPerMin;
        e.SilverPool += e.SilverPerMin;
        e.GoldPool += e.GoldPerMin;
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
        gun.Damage += 10;
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
    }
    public void AddSilver(int amount)
    {
        Silver += amount;
    }
    public void AddGold(int amount)
    {
        Gold += amount;
    }
    public void RemoveCopper(int amount)
    {
        Copper -= amount;
        if (Copper < 0) Copper = 0;
    }
    public void RemoveSilver(int amount)
    {
        Silver -= amount;
        if (Silver < 0) Silver = 0;
    }
    public void RemoveGold(int amount)
    {
        Gold -= amount;
        if (Gold < 0) Gold = 0;
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