using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void OnStartBtnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitBtnClick()
    {
        Application.Quit();
    }
}
