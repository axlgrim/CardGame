using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Text TimerField;
    public Text ScoreField;
    public Text UserInfo;
    public Text EndGameMessage;
    public GameObject PauseMenu;
    public GameObject EndGame;

    public GameManager Manager;

    private float _timer;

    private int _totalGuessed = 6;
    private int _minutes;
    private int _seconds;
    private bool _ended = false;

    private float _countdown;

    private Color _winColor;
    private Color _looseColor;


    void Awake()
    {
        var textAsset = Resources.Load<TextAsset>("Config");
        _countdown = Convert.ToInt32(textAsset.text);
    }

    void Start()
    {
        EndGame.SetActive(false);
        Resume();
        
    }

    void Update()
    {

        var remain = Convert.ToDouble(_countdown - ((int)_timer % 60));

        ScoreField.text = Manager.guessedCards.ToString() + "/" + _totalGuessed.ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && !_ended)
        {
            if (Manager.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (remain < 0)
        {
            Finish(Color.red, "DEFEAT!");
        }
        else if(Manager.guessedCards == _totalGuessed)
        {
            Finish(Color.green, "WIN!");
        }
        else
        {
            _timer = Time.timeSinceLevelLoad;
            _minutes = ((int)_timer / 60);
            _seconds = ((int)_timer % 60);
            TimerField.text = _minutes.ToString() + ":" + _seconds.ToString();
            UserInfo.text = "You have " + remain.ToString() + " seconds to win the game!";
        }


    }
    public void OnResumeBtnClicked()
    {
        Resume();
    }

    public void OnMenuBtnClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuitBtnClicked()
    {
        Application.Quit();
        //System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    public void OnRestartBtnClicked()
    {
        SceneManager.LoadScene("TestSCene");
    }

    void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Manager.isPaused = false;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Manager.isPaused = true;
    }

    void Finish(Color color, string message)
    {
        EndGame.SetActive(true);
        EndGameMessage.color = color;
        EndGameMessage.text = message;
        _ended = true;

    }
}
