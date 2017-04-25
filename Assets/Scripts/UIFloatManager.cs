using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFloatManager : MonoBehaviour {

    private static UIFloatManager s_instance = null;
    public static UIFloatManager Instance
    {
        get
        {
            return s_instance;
        }
    }

    private void Awake()
    {
        if (s_instance != null) Debug.LogError("UIFloatManager already exists.");
        s_instance = this;
    }

    public UIFloating[] UIFloats;
    private int current = -1;
    
    void Start () {
        current = -1;
	}
	
	void Update () {
        if(current == -1)
        {
            return;
        }
        UIFloats[current].show();
	}

    public void ShowUI(int index)
    {
        HideUI();
        current = index;
    }

    public void HideUI()
    {
        foreach(UIFloating ui in UIFloats)
        {
            ui.hide();
        }
        current = -1;
    }
}
