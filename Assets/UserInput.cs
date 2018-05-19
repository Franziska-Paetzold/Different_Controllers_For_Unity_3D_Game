using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;
using Leap.Unity;


public class UserInput : MonoBehaviour {

    public GameObject menu;
    private bool menuFlag = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (menuFlag == true)
            {
                menu.SetActive(false);
                menuFlag = false;
                Time.timeScale = 1;

            }
            else
            {
                menu.SetActive(true);
                menuFlag = true;
                Time.timeScale = 0;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Return()
    {
        menu.SetActive(false);
        menuFlag = false;
        Time.timeScale = 1;
    }
}
