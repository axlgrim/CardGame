using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Text TimerField;
    public Text ScoreField;
    public GameObject PauseMenu;

    public GameManager Manager;

    private float _timer;

    private int _totalGuessed = 6;
    private string _minutes;
    private string _seconds;

    


    void Start()
    {
        Resume();
    }

    void Update()
    {
        _timer = Time.timeSinceLevelLoad;
        _minutes = ((int)_timer / 60).ToString();
        _seconds = ((int)_timer % 60).ToString();
        TimerField.text = _minutes + ":" + _seconds;

        ScoreField.text = Manager.guessedCards.ToString() + "/" + _totalGuessed.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
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
}
