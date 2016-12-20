using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    const int defaultMin = 1;
    const int defaultMax = 1000;
    int min;
    int max;
    int guess;
    int maxGuessesAllowed = 10;

    public Text text;

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
        max ++;
    }

    // Update is called once per frame

    public void GuessHigher() {
        min = guess;
        GuessNumber();
    }

    public void GuessLower() {
        max = guess;
        GuessNumber();
    }


    private void GuessNumber()
    {
        guess = (min + max) / 2;
        text.text = guess.ToString();
        maxGuessesAllowed --;
        if(maxGuessesAllowed <= 0) {
            SceneManager.LoadScene("Win");
        }
    }
}
