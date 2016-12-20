using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { start, cell, mirror, sheets_0, sheets_1, lock_0, lock_1, cell_mirror, freedom};
    private States myState;

    // Use this for initialization
    void Start () {
        text.text = "Press Space to start";
	}
	
	// Update is called once per frame
	void Update () {
        if (myState == States.start)
        {
            begin();
        } else if(myState == States.cell)
        {
            state_cell();
        }

	}

    private void begin()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myState = States.cell;
            storyDictionary("cell");
        }

    }

    void state_cell()
    {
        storyDictionary("cell");
    }

    void storyDictionary(string key)
    {
        Dictionary<string, string> storyTexts = new Dictionary<string, string>();

        storyTexts.Add("cell", "You are in a prison cell, and you want to escape. There are some dirty sheets on the bed, a " +
        "mirror on the wall, and the door is locked from the outside.\n\n Press S to look at the SHEETS\n\n" +
        "Press M to look at the MIRROR\n\nPress L to look at the LOCK");
        storyTexts.Add("mutant", "mut");
        text.text = storyTexts[key];
    }

}
