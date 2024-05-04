using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private GameObject GameUI;
    [SerializeField] private GameObject WinLossUI;
    [SerializeField] private TextMeshProUGUI winLossText;
    [SerializeField] private TextMeshProUGUI replayButtonText;
    [SerializeField] private TextMeshProUGUI quitButtonText;

    public Slider healthBar;
    private int health;

    private bool healthGone = false;

    // Start is called before the first frame update
    void Start()
    {

        health = 20;
        healthBar.value = health;
    }

    public void damage()
    {
        health--;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        //game over
        if(health <= 0 && healthGone == false)
        {
            healthGone = true;
            StartCoroutine(closing());
        }
    }

    IEnumerator closing()
    {
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(1);
        //display win screen
        Time.timeScale = 0;
        health = 1;
        GameUI.SetActive(false);
        WinLossUI.SetActive(true);
        winLossText.text = "You Lost!";
        replayButtonText.text = "Try Again";
        quitButtonText.text = "Return to Main Menu";
    }
}
