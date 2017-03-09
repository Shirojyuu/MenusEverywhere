//2017 Alec Day

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour {
    [SerializeField]
    private MenuItem[] items;
    [SerializeField]
    private int selectIndex = 0;
    [SerializeField]
    private GlobalMenuControl parentController;

    private string selectedAction;

    public AudioSource source;
    public AudioClip cursorSound;
    public AudioClip selectSound;

    public bool enableMovement = true;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

        //Navigation
        if (enableMovement)
        {
            if (Input.GetButtonDown("DPad Down") || Input.GetAxis("DU-Axis") > 0)
            {
                source.PlayOneShot(cursorSound);
                selectIndex++;
            }

            if (Input.GetButtonDown("DPad Up") || Input.GetAxis("DU-Axis") < 0)
            {
                source.PlayOneShot(cursorSound);
                selectIndex--;
            }
        }

        //Select bounds
        if(selectIndex < 0)
        {
            items[selectIndex + 1].highlighted = false;
            selectIndex = items.Length - 1;
        }

        if(selectIndex > items.Length - 1)
        {
            items[selectIndex - 1].highlighted = false;
            selectIndex = 0;
        }

        items[selectIndex].highlighted = true;
        selectedAction = items[selectIndex].GetAction();

        if (selectIndex == 0)
            items[selectIndex + 1].highlighted = false;

        if (selectIndex == items.Length - 1)
            items[selectIndex - 1].highlighted = false;

        if (selectIndex > 0 && selectIndex < items.Length - 1)
        {
            items[selectIndex + 1].highlighted = false;
            items[selectIndex - 1].highlighted = false;
        }

        //Selection of a menu item
        if(Input.GetButtonDown("Fire1"))
        {
            source.PlayOneShot(selectSound);
            switch(selectedAction)
            {
                case "Equipment":
                    parentController.ChangeMenuLevel(1);
                    break;

                case "Abilities":
                    parentController.ChangeMenuLevel(2);
                    break;

                case "Settings":
                    parentController.ChangeMenuLevel(3);
                    break;
            }
        }
	}
}
