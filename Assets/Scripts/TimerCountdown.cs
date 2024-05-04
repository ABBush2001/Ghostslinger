using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject WinLossUI;
    [SerializeField] private TextMeshProUGUI WinLossText;
    [SerializeField] private TextMeshProUGUI ReplayButton;
    [SerializeField] private TextMeshProUGUI QuitButton;

    [SerializeField] private GameObject eventSystem;

    public float timeRemaining = 10f;
    public float endTime = 0f;
    public bool timerRunning = false;
    public TextMeshProUGUI timerText;

    private GameObject levelManager;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
        levelManager = GameObject.Find("LevelManager");
    }
    // Update is called once per frame
    void Update()
    {
        if (eventSystem.GetComponent<LevelOpening>().getAnimFinished())
        {
            
            if (timerRunning)
            {
                if (timeRemaining > endTime)
                {
                    timeRemaining -= Time.deltaTime;
                    timerText.text = ("Time Remaining: ") +
                    Mathf.FloorToInt(timeRemaining + 1).ToString();
                }
                else
                {
                    timerRunning = false;
                    timeRemaining = 0;
                    Debug.Log("Time Out");
                    timerText.text = ("Time Remaining: ") +
                    Mathf.FloorToInt(timeRemaining).ToString();

                    //update level
                    levelManager.GetComponent<LevelManager>().updateLevel();

                    //display win screen
                    Time.timeScale = 0;
                    GameUI.SetActive(false);
                    WinLossUI.SetActive(true);
                    WinLossText.text = "You Win!";
                    ReplayButton.text = "Go To Next Level";
                    QuitButton.text = "Return to Main Menu";
                }
            }
        }
    }
}
