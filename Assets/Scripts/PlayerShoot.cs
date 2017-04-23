using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public Camera FPSCam;
    public Slider sliderMid;
    
    private float foo;

    // Use this for initialization
    void Start () {
        foo = 0;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, 20))
        {
            if (hit.collider.tag.StartsWith("Enemy"))
            {
                foo += Time.deltaTime;
                if(foo >= GameManager.Instance.gun.maxCharge)
                {
                    foo = 0;
                    EnemyManager.Instance.OnEnemyDie();
                    Destroy(hit.collider.gameObject);
                }
            }
            else
            {
                foo = 0;
            }
        }
        else
        {
            foo = 0;
        }
        UpdateSlider();
    }

    void UpdateSlider()
    {
        sliderMid.value = (foo * 100 ) / GameManager.Instance.gun.maxCharge;
    }
}
