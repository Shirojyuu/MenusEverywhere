using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour {
    [SerializeField]
    private Color selectColor;
    [SerializeField]
    private string actionOnSelect;
    [SerializeField]
    private Image itemBackground;
    [SerializeField]
    private Text itemText;
    [SerializeField]
    private string displayOption;
    public bool highlighted;
    

	// Use this for initialization
	void Start () {
        itemText.text = displayOption;
	}
	
	// Update is called once per frame
	void Update () {
		if(highlighted)
        {
            itemBackground.color = selectColor;
        }

        else
        {
            itemBackground.color = Color.white;
        }
	}

    public string GetAction()
    {
        return actionOnSelect;
    }

    public void ChangeItemText(string newText)
    {
        itemText.text = newText;
    }
}
