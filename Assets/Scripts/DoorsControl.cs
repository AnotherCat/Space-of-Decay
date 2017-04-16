using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsControl : MonoBehaviour {

    private static DoorsControl s_instance = null;
    public static DoorsControl Instance
    {
        get
        {
            return s_instance;
        }
    }
    private void Awake()
    {
        if (s_instance != null) Debug.LogError("DoorsControl already exists.");
        s_instance = this;
    }
    private void OnDestroy()
    {
        if (s_instance == this) s_instance = null;
    }

    public Animator[] doorAnimators;
    public bool[] locked = new bool[] { true, true };
    public void OpenDoor(int index)
    {
        if (!doorAnimators[index].GetCurrentAnimatorStateInfo(0).IsName("open") || !doorAnimators[index].GetCurrentAnimatorStateInfo(0).IsName("close"))
        {
            doorAnimators[index].SetTrigger("open");
        }
    }

    public void CloseDoor(int index)
    {
        if (!doorAnimators[index].GetCurrentAnimatorStateInfo(0).IsName("open") || !doorAnimators[index].GetCurrentAnimatorStateInfo(0).IsName("close"))
        {
            doorAnimators[index].SetTrigger("close");
        }
    }
}
