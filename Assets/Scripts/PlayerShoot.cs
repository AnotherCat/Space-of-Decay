using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public Camera FPSCam;
    public Slider sliderMid;
    public AudioClip[] clips; // 0 charge , 1 - 5 laser shoot
    
    private float foo;
    private AudioSource s;

    // Use this for initialization
    void Start () {
        foo = 0;
        s = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, 20))
        {
            if (hit.collider.tag.StartsWith("Enemy"))
            {
                foo += Time.deltaTime;
                s.clip = clips[0];
                s.Play();
                if (foo >= GameManager.Instance.gun.maxCharge)
                {
                    foo = 0;
                    s.clip = clips[Random.Range(1, clips.Length)];
                    s.Play();
                    EnemyManager.Instance.OnEnemyDie();
                    Destroy(hit.collider.gameObject);
                    if (Random.Range(0, 2) == 1)
                    {
                        int copper = Random.Range(20, 60);
                        GameManager.Instance.AddCopper(copper);
                        NotificationText.Instance.AddNotification(copper + " Copper Added !!");
                    }
                    if (Random.Range(0, 2) == 1)
                    {
                        int silver = Random.Range(10, 20);
                        GameManager.Instance.AddSilver(silver);
                        NotificationText.Instance.AddNotification(silver + " Silver Added !!");
                    }
                    if (Random.Range(0, 2) == 1)
                    {
                        int gold = Random.Range(2, 10);
                        GameManager.Instance.AddGold(gold);
                        NotificationText.Instance.AddNotification(gold + " Gold Added !!");
                    }
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
