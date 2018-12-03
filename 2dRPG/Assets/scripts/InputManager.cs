using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    public Image currentSpellImage;
    public Sprite spellSlot1Sprite;
    public Sprite spellSlot2Sprite;
    public Sprite spellSlot3Sprite;

    public GameObject menu;
    private bool isShowing;

    public GameObject mainMenu;
    public GameObject statsMenu;
    public GameObject spellsMenu;

    public Player player; 


    // Use this for initialization
    void Start () {
        isShowing = false;
        menu.SetActive(isShowing);
        hideEverything();
    }

    //TODO need to add EventSystem to project.....
	
	// Update is called once per frame
	void Update () {
        getPlayerInput();

        if (Input.GetKeyDown("space"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
            mainMenu.SetActive(isShowing);

            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                hideEverything();
            }
            else
            {
                Time.timeScale = 0f;
            }
        }
    }

    void getPlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.canTakeAction = false;
            player.anim.SetBool("iscasting", true);
            player.anim.SetBool("iswalking", false);
        }

        if (Input.GetKeyDown("1"))
        {
            currentSpellImage.sprite = spellSlot1Sprite;
            player.currentSpell = player.spellBook.spells[0];
        }

        if (Input.GetKeyDown("2"))
        {
            currentSpellImage.sprite = spellSlot2Sprite;
            player.currentSpell = player.spellBook.spells[1];
        }

        if (Input.GetKeyDown("3"))
        {
            currentSpellImage.sprite = spellSlot3Sprite;
            player.currentSpell = player.spellBook.spells[2];
        }
    }

    private void hideEverything()
    {
        mainMenu.SetActive(false);
        statsMenu.SetActive(false);
        spellsMenu.SetActive(false);
    }

    public void goBack()
    {
        hideEverything();
        mainMenu.SetActive(true);
    }

    public void statsPress()
    {
        hideEverything();
        Text hpVal = statsMenu.transform.Find("hpVal").GetComponent<Text>();
        hpVal.text = player.health.ToString();
        statsMenu.SetActive(true);
    }

    public void spellsPress()
    {
        spellsMenu.SetActive(true);
    }

}
