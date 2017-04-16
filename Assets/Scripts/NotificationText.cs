using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationText : MonoBehaviour {

    private static NotificationText s_instance = null;
    public static NotificationText Instance
    {
        get
        {
            return s_instance;
        }
    }
    private void Awake()
    {
        if (s_instance != null) Debug.LogError("NotificationText already exists.");
        s_instance = this;
    }
    private void OnDestroy()
    {
        if (s_instance == this) s_instance = null;
    }

    public Transform parentCanvas;

    public string TextPrefabPath = "";

    

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddNotification(string str)
    {
        AddNotification(str, 3);
    }

    public void AddNotification(string str,float time)
    {
        GameObject t = Instantiate(Resources.Load<GameObject>(TextPrefabPath));
        t.GetComponentInChildren<Text>().text = str;
        t.transform.SetParent(parentCanvas);
        Destroy(t.gameObject, time);
    }

}
