using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationText : MonoBehaviour {

    public static NotificationText Instance;

    public Transform parentCanvas;

    public string TextPrefabPath = "";

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

    public void NotificationAdd(string str)
    {
        NotificationAdd(str, 3);
    }

    public void NotificationAdd(string str,float time)
    {
        GameObject t = Instantiate(Resources.Load<GameObject>(TextPrefabPath));
        t.GetComponentInChildren<Text>().text = str;
        t.transform.SetParent(parentCanvas);
        Destroy(t.gameObject, time);
    }

}
