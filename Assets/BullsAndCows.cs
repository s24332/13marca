using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class BullsAndCows : MonoBehaviour
{
    public TextMeshProUGUI secretWordText;
    public TextMeshProUGUI secretWordLenghtText;
    public TextMeshProUGUI msgText;

    public TMP_InputField inputField;

    public List<string> words = new List<string>();

    int lives = 3;
    string secretWord = "hello";
    
    void Start()
    {
        secretWord = words[Random.Range(0, words.Count-1)];

        secretWordText.text = "Try and guess" + secretWord + ".";
        secretWordLenghtText.text = "secret word length " + secretWord.Length + ".";
        DisplayPlayerLives();

        
        Debug.Log("Player has " + lives + " lives");
        Debug.Log("Secret word is " + secretWord + ".");
        Debug.Log("secret word length " + secretWord.Length + ".");

    }


    void Update()
    {
        
    }

    // hello
    // length = 5
    // hello [0] = h
    // hello [1] = e
    // hello [2] = l
    // hello [3] = l
    // hello [4] = o

    
    public void OnButtonClick()
    {
        if (lives > 0)
        {
            if(secretWord == inputField.text)
            {
                secretWordText.text = "Congratulations";
                return;

            }

            if (secretWord.Length == inputField.text.Length)
            {
                int bullsCount = 0;
                //secretWord[?] == guess[?], gdzie ?==?
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == inputField.text[i])
                    {
                        bullsCount++;
                    }
                }

                int cowsCount = 0;
                //secretWord[?] == guess[?], gdzie ?==?
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] != inputField.text[i] && inputField.text.Contains(secretWord[i]))
                    {
                        cowsCount++;
                    }
                }

                lives--;
                secretWordText.text = "Bulls: " + bullsCount + "cows: " + cowsCount;
                DisplayPlayerLives();
            }

            else
            {
                lives--;
                secretWordText.text = "Wrong length";
                DisplayPlayerLives();
            }
            inputField.text = "";
        }
        else
        {
            secretWordText.text = "You lost";
            DisplayPlayerLives();
        }

    }

    void DisplayPlayerLives()
    {
        msgText.text = "Player has " + lives + " lives";
    }
      
           
    
}
