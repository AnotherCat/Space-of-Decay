using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcavatorControl : MonoBehaviour {

    private static ExcavatorControl s_instance = null;
    public static ExcavatorControl Instance
    {
        get { return s_instance; }
    }
    private void Awake()
    {
        if (s_instance != null) Debug.LogError("ExcavatorControll already exists.");
        s_instance = this;
    }

    public Animator[] ExcavatorAnimators;
    public AudioSource[] Sounds;
    
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExcavatorOn(int index)
    {
        ExcavatorAnimators[index].SetTrigger("on");
        Sounds[index].Play();
    }

    public void ExcavatorOff(int index)
    {
        ExcavatorAnimators[index].SetTrigger("off");
        Sounds[index].Stop();
    }
}
