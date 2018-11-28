using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject menu; // Assign in inspector
    private bool isShowing;

    // Use this for initialization
    void Start () {
        isShowing = false;
        menu.SetActive(isShowing);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                //return (false);
            }
            else
            {
                Time.timeScale = 0f;
                // return (true);
            }
        }
    }
}
