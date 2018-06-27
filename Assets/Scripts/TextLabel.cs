using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextLabel : MonoBehaviour {

    public Text timerField;
    public Text scoreField;

    public GameManager Manager;

    private float timer;

    private int totalGuessed = 6;
    private string minutes;
    private string seconds;

    private void Update()
    {
        timer = Time.time;
        minutes = ((int)timer / 60).ToString();
        seconds = ((int)timer % 60).ToString();
        timerField.text = minutes + ":" + seconds;

        scoreField.text = Manager.guessedCards.ToString() + "/" + totalGuessed.ToString();


    }
}
