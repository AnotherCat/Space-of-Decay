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
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("popup")).SetText("Computer", "this is computer.").ShowButton("ok", () => {
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    });
                }
            }
            else if (name.StartsWith("excavator1"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("excavator")).SetText("Excavator01", "").ShowButton("start", () =>
                    {
                        Debug.Log("Start!!");
                        ExcavatorControl.Instance.ExcavatorOn(0);
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    }).ShowButton("upgrade", () =>
                    {
                        Debug.Log("Upgrade!!");

                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    }).ShowButton("close", () =>
                 {
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    });
                }
            }
            else if (name.StartsWith("excavator2"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("excavator")).SetText("Excavator02", "").ShowButton("start", () =>
                    {
                        Debug.Log("Start!!");
                        ExcavatorControl.Instance.ExcavatorOn(1);
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    }).ShowButton("upgrade", () =>
                    {
                        Debug.Log("Upgrade!!");

                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    }).ShowButton("close", () =>
                    {
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    });
                }

            }
            else if (name.StartsWith("excavator3"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {

                    GameManager.Instance.FreezPlayer(true);
                    GameManager.Instance.Pause();
                    ((uMyGUI_PopupText)uMyGUI_PopupManager.Instance.ShowPopup("excavator")).SetText("Excavator03<Broken>", "").ShowButton("start", () =>
                    {
                        Debug.Log("Start!!");
                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    }).ShowButton("upgrade", () =>
                    {
                        Debug.Log("Upgrade!!");

                        GameManager.Instance.FreezPlayer(false);
                        GameManager.Instance.Unpause();
                    }).ShowButton("close", () =>
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
