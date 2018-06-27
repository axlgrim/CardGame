using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Text timerField;
    public Text scoreField;
    public GameObject pauseMenu;

    public GameManager Manager;

    private float timer;

    private int totalGuessed = 6;
    private string minutes;
    private string seconds;

    public bool isPaused = false;


    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        timer = Time.time;
        minutes = ((int)timer / 60).ToString();
        seconds = ((int)timer % 60).ToString();
        timerField.text = minutes + ":" + seconds;

        scoreField.text = Manager.guessedCards.ToString() + "/" + totalGuessed.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;


            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;

            }
        }


    }
    public void onResumeBtnClicked()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
