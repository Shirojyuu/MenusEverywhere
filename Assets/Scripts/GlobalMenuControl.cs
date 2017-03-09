using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMenuControl : MonoBehaviour {
    [SerializeField]
    private MenuSystem[] submenus;

    [SerializeField]
    private int menuLevel = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0 ; i < submenus.Length; i++)
        {
            if (i == menuLevel)
                submenus[i].enableMovement = true;

            else
                submenus[i].enableMovement = false;
        }

        if(Input.GetButtonDown("Fire2"))
        {
            ChangeMenuLevel(0);
        }
	}

    public void ChangeMenuLevel(int level)
    {
        menuLevel = level;
    }
}
