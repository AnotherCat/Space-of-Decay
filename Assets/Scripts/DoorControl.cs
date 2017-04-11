using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {

    public static DoorControl Instance;

    public Animator[] doorAnimators;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDoor(int index)
    {
        if(!doorAnimators[index].GetCurrentAnimatorStateInfo(0).IsName("open") || !doorAnimators[index].GetCurrentAnimatorStateInfo(0).IsName("close"))
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
