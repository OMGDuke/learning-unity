using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    const int defaultMin = 1;
    const int defaultMax = 1000;
    int min;
    int max;
    int guess;
    bool winner;


    // Use this for initialization
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        min = defaultMin;
        max = defaultMax;
        guess = (min + max) / 2;
        winner = false;
        print("========================");
        print("========================");
        print("Welcome to Number Wizard");
        print("Pick a number, but don't tell me!");

        print("The lowest number you can pick is " + min);
        print("The highest number you can pick is " + max);

        print("Is the number higher or lower than " + guess + "?");
        print("Up arrow for higher, down arrow for lower, Enter for equal.");
        max ++;
    }

    // Update is called once per frame
    void Update()
    {
        CheckKey();
    }

    private void CheckKey()
    {
        if (winner == true && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            print("Hey! No cheating! I already won! Press Backspace to start again.");
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            GuessNumber();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            GuessNumber();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            IWin();
        }
        else if (winner == true && Input.GetKeyDown(KeyCode.Backspace))
        {
            StartGame();
        }
    }

    private void GuessNumber()
    {
        guess = (min + max) / 2;
        print("Is it " + guess + "?");
    }

    private void IWin()
    {
        winner = true;
        print("I win, your number was " + guess + "!");
        print("To restart press backspace.");
    }
}
