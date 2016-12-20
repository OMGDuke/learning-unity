using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States { begin, cell, cell_mirror, sheets_0, sheets_1, mirror, lock_0, lock_1, freedom};
    private States myState;
    Dictionary<string, string> storyTexts = new Dictionary<string, string>();

    // Use this for initialization
    void Start () {
        createStoryDictionary();
        text.text = "Press Space to start";
	}
	
	// Update is called once per frame
	void Update () {
        if (myState == States.begin) {
            state_begin();
        } else if(myState == States.cell) {
            state_cell();
        } else if (myState == States.cell_mirror) {
            state_cell_mirror();
        } else if (myState == States.sheets_0) {
            state_sheets_0();
        } else if (myState == States.sheets_1) {
            state_sheets_1();
        } else if (myState == States.mirror) {
            state_mirror();
        } else if (myState == States.lock_0) {
            state_lock_0();
        } else if (myState == States.lock_1) {
            state_lock_1();
        } else if (myState == States.freedom) {
            state_freedom();
        }
    }

    // States

    void state_begin() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            myState = States.cell;
        }
    }

    void state_cell() {
        storyDictionary("cell");
        if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.sheets_0;
        } else if (Input.GetKeyDown(KeyCode.M)) {
            myState = States.mirror;
        } else if (Input.GetKeyDown(KeyCode.L)) {
            myState = States.lock_0;
        }
    }

    void state_cell_mirror() {
        storyDictionary("cell_mirror");
        if (Input.GetKeyDown(KeyCode.S)) {
            myState = States.sheets_1;
        } else if (Input.GetKeyDown(KeyCode.L)) {
            myState = States.lock_1;
        }
    }

    void state_sheets_0() {
        storyDictionary("sheets_0");
        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }

    void state_sheets_1() {
        storyDictionary("sheets_1");
        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell_mirror;
        }
    }

    void state_mirror() {
        storyDictionary("mirror");
        if(Input.GetKeyDown(KeyCode.T)) {
            myState = States.cell_mirror;
        } else if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }

    void state_lock_0() {
        storyDictionary("lock_0");
        if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell;
        }
    }

    void state_lock_1() {
        storyDictionary("lock_1");
        if(Input.GetKeyDown(KeyCode.O)) {
            myState = States.freedom;
        } else if (Input.GetKeyDown(KeyCode.R)) {
            myState = States.cell_mirror;
        }
    }

    void state_freedom() {
        storyDictionary("freedom");
        if (Input.GetKeyDown(KeyCode.P)) {
            myState = States.cell;
        }
    }

    // Dictionary

    void storyDictionary(string key) {
        text.text = storyTexts[key];
    }

    void createStoryDictionary() {
        storyTexts.Add("cell", "You are in a prison cell, and you want to escape. There are some dirty sheets on the bed, a " +
            "mirror on the wall, and the door is locked from the outside.\n\n Press S to look at the SHEETS\n\n" +
            "Press M to look at the MIRROR\n\nPress L to look at the LOCK");
        storyTexts.Add("cell_mirror", "You are still in your cell, and you STILL want to escape! There are some dirty sheets " +
            "on the bed, a mark where the mirror was, and that pesky door is still there, and firmly locked!\n\n" +
            "Press S to view SHEETS, or L to view LOCK");
        storyTexts.Add("sheets_0", "You can't believe you sleep in these things. Surely it's time somebody changed them. " +
            "The pleasures of prison life I guess!\n\nPress R to RETURN to roaming your cell.");
        storyTexts.Add("sheets_1", "Holding a mirror in your hand doesn't make the sheets look any better.\n\n" +
            "Press R to RETURN to roaming your cell");
        storyTexts.Add("mirror", "The dirty old mirror on the wall seems loose.\n\nPress T to Take the mirror, or R to RETURN " +
            "to roaming your cell");
        storyTexts.Add("lock_0", "This is one of those 4 digit code locks. You have no idea what the combination is. You " +
            "wish you could somehow see where the dirty fingerprints were to be able to guess the code, but the buttons are " +
            "on the outside of the cell.\n\nPress R to RETURN to roaming your cell.");
        storyTexts.Add("lock_1", "You carefully put the mirror through the bars, and turn it round so you can see the lock. " +
            "You can just make out fingerprints around the buttons. You press the dirty buttons, and hear a click.\n\n" +
            "Press O to OPEN, or R to RETURN to your cell.");
        storyTexts.Add("freedom", "You are FREE!\n\nPress P to PLAY again.");
    }
}
