using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFloating : MonoBehaviour {

    public float distancetoHide = 20;
    public string prefabName;

    private GameObject ParentTransform;
    private Transform floatingImage;
    private Transform instance;
    private GameObject player;

	void Start () {
        ParentTransform = GameObject.Find("Canvas/UIFloatParentTransform");
        floatingImage = Resources.Load<Transform>("Prefabs/UI/" + prefabName);
        player = GameObject.FindGameObjectWithTag("Player");

        instance = Instantiate(floatingImage);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        instance.SetParent(ParentTransform.transform, false);
        instance.position = screenPosition;
        hide();
	}
	
	void Update () {
        if (Camera.main == null) return;
        if (player == null)
        {
            hide();
            return;
        }

    }

    public void show()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        instance.position = screenPosition;
        if ((screenPosition.z > 0 &&
            screenPosition.x > 0 && screenPosition.x < Screen.width &&
            screenPosition.y > 0 && screenPosition.y < Screen.height) &&
            Vector3.Distance(player.transform.position, transform.position) < distancetoHide)
        {
            instance.gameObject.SetActive(true);
        }
        else // offscreen
        {
            hide();
        }
    }
    public void hide()
    {
        instance.gameObject.SetActive(false);
    }
}
