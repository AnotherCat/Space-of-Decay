using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcavatorControl : MonoBehaviour {

    public static ExcavatorControl Instance;

    public Animator[] ExcavatorAnimators;

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

    public void ExcavatorOn(int index)
    {
        ExcavatorAnimators[index].SetTrigger("on");
    }

    public void ExcavatorOff(int index)
    {
        ExcavatorAnimators[index].SetTrigger("off");
    }
}
