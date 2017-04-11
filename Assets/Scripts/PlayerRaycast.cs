using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour {

    public Camera FPSCam;
    public GameObject HandPanel;

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
		if(Physics.Raycast(FPSCam.transform.position,FPSCam.transform.forward,out hit, 2))
        {
            if (hit.collider.name.StartsWith("button1"))
            {
                HandPanel.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DoorControl.Instance.OpenDoor(0);
                }
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
