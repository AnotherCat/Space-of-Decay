using System.Collections;
using System.Collections.Generic;
using uMyGUI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour {

    public Camera FPSCam;
    public GameObject HandPanel;

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, 2))
        {
            string name = hit.collider.name;
            if (name.StartsWith("button1") || name.StartsWith("button2"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DoorsControl.Instance.OpenDoor(0);
                }
            }
            else if (name.StartsWith("button3") || name.StartsWith("button4"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DoorsControl.Instance.OpenDoor(1);
                }
            }
            else if (name.StartsWith("computer"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("dragdrop")).ShowButton("close", () =>
                     {
                         GameManager.Instance.FreezPlayer(false);
                         GameManager.Instance.Unpause();
                     });
                    //((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("computer")).SetText("Computer", "this is computer.").ShowButton("craft", () =>
                    //{
                    //    GameManager.Instance.FreezPlayer(false);
                    //    GameManager.Instance.Unpause();
                    //}).ShowButton("excavator", () =>
                    //{
                    //    GameManager.Instance.FreezPlayer(false);
                    //    GameManager.Instance.Unpause();
                    //}).ShowButton("weapon", () =>
                    //{
                    //    GameManager.Instance.FreezPlayer(false);
                    //    GameManager.Instance.Unpause();
                    //}).ShowButton("close", () =>
                    //{
                    //    GameManager.Instance.FreezPlayer(false);
                    //    GameManager.Instance.Unpause();
                    //});
                }
            }
            else if (name.StartsWith("excavator1"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!GameManager.Instance.ext[0].startedFlag)
                    {
                        GameManager.Instance.FreezPlayer(true);
                        GameManager.Instance.Pause();

                        ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("excavator")).SetText("Excavator01", "Level " + GameManager.Instance.ext[0].level).ShowButton("copper", () =>
                        {
                            GameManager.Instance.StartExcavator(0, 100, 0, 0);
                            ExcavatorControl.Instance.ExcavatorOn(0);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("silver", () =>
                        {
                            GameManager.Instance.StartExcavator(0, 0, 60, 0);
                            ExcavatorControl.Instance.ExcavatorOn(0);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("gold", () =>
                        {
                            GameManager.Instance.StartExcavator(0, 0, 0, 10);
                            ExcavatorControl.Instance.ExcavatorOn(0);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("close", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                    }
                    else
                    {
                        if (GameManager.Instance.ext[0].finishedFlag)
                        {
                            Excavator e = GameManager.Instance.ext[0];
                            e.startedFlag = false;
                            e.finishedFlag = false;
                            GameManager.Instance.AddCopper(e.CopperPerMin);
                            GameManager.Instance.AddSilver(e.SilverPerMin);
                            GameManager.Instance.AddGold(e.GoldPerMin);
                            //GameManager.Instance.RestartExcavator(0);
                            if (e.CopperPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Copper + " + e.CopperPerMin);
                            }
                            if(e.SilverPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Silver + " + e.SilverPerMin);
                            }
                            if(e.GoldPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Gold + " + e.GoldPerMin);
                            }
                            e.progressWheel.value = 0;
                        }
                    }
                }
            }
            else if (name.StartsWith("excavator2"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!GameManager.Instance.ext[1].startedFlag)
                    {
                        GameManager.Instance.FreezPlayer(true);
                        GameManager.Instance.Pause();
                        ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("excavator")).SetText("Excavator02", "Level " + GameManager.Instance.ext[1].level).ShowButton("copper", () =>
                        {
                            GameManager.Instance.StartExcavator(1, 100, 0, 0);
                            ExcavatorControl.Instance.ExcavatorOn(1);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("silver", () =>
                        {
                            GameManager.Instance.StartExcavator(1, 0, 60, 0);
                            ExcavatorControl.Instance.ExcavatorOn(1);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("gold", () =>
                        {
                            GameManager.Instance.StartExcavator(1, 0, 0, 10);
                            ExcavatorControl.Instance.ExcavatorOn(1);
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        }).ShowButton("close", () =>
                        {
                            GameManager.Instance.FreezPlayer(false);
                            GameManager.Instance.Unpause();
                        });
                    }
                    else
                    {
                        if (GameManager.Instance.ext[1].finishedFlag)
                        {
                            Excavator e = GameManager.Instance.ext[1];
                            e.startedFlag = false;
                            e.finishedFlag = false;
                            GameManager.Instance.AddCopper(e.CopperPerMin);
                            GameManager.Instance.AddSilver(e.SilverPerMin);
                            GameManager.Instance.AddGold(e.GoldPerMin);
                            //GameManager.Instance.RestartExcavator(1);
                            if (e.CopperPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Copper + " + e.CopperPerMin);
                            }
                            if (e.SilverPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Silver + " + e.SilverPerMin);
                            }
                            if (e.GoldPerMin > 0)
                            {
                                NotificationText.Instance.AddNotification("Gold + " + e.GoldPerMin);
                            }
                            e.progressWheel.value = 0;
                        }
                    }
                        
                }

            }
            else if (name.StartsWith("excavator3"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Excavator03<Broken>", "Broken...").ShowButton("ok", () =>
                    {

                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    });
                }
            }
            else if (name.StartsWith("rocket"))
            {
                HandPanel.SetActive(true);

            }
            else
            {
                hideAllUI();
            }
        }
        else
        {
            hideAllUI();
        }
	}

    void hideAllUI()
    {
        HandPanel.SetActive(false);
    }
}
