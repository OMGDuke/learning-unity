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
    public int maxGuessesAllowed = 11;

    public Text text;

    // Use this for initialization
    void Start()
    {
        StartGame();
        GuessNumber();
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
        guess = Random.Range(min, max);
        text.text = guess.ToString();
        maxGuessesAllowed --;
        if(maxGuessesAllowed <= 0) {
            SceneManager.LoadScene("Win");
        }
    }
}
